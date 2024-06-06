using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Simplon;

public class VehicleMovement : MonoBehaviour
{
    public float speed;

    [Header("Drive Settings")]
    public float driveForce = 17F;
    public float slowingVelFactor = 0.99f;
    public float brakingVelFactor = 0.95F;
    public float angleOfRoll = 30F;

    [Header("Hover Setting")]
    public float hoverHeight = 1.5f;
    public float maxGroundDist = 5f;
    public float hoverForce = 300f;
    public LayerMask whatIsGround;
    public PIDController hoverPID;

    [Header("Physic Settings")]
    public Transform shipBody;
    public float terminalVelocity = 100F;
    public float hoverGravity = 20f;
    public float fallGravity = 80f;

    Rigidbody rigidbody;
    PlayerInput input;
    float drag;
    bool isOnGround;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        input=GetComponent<PlayerInput>();

        drag = driveForce / terminalVelocity;
    }

    private void FixedUpdate() {
        speed = Vector3.Dot(rigidbody.velocity, transform.forward);

        CalculateHover();
        CalculatePropulsion();

    }
    private void Update()
    {
        //Debug.Log(GetSpeedPercentage());
        //actualizo la velocidad en el game controler
        GameControler.instance.actualizarSpeed(GetSpeedPercentage());
    }
    void CalculateHover() {
        Vector3 groundNormal;
        Ray ray = new Ray(transform.position, -transform.up);

        RaycastHit hitInfo;

        isOnGround = Physics.Raycast(ray, out hitInfo, maxGroundDist, whatIsGround);

        if (isOnGround) {
            float height = hitInfo.distance;
            groundNormal = hitInfo.normal.normalized;
            float forcePercent = hoverPID.Seek(hoverHeight, height);
            Vector3 force = groundNormal * hoverForce * forcePercent;

            Vector3 gravity = -groundNormal * hoverGravity * height;

            rigidbody.AddForce(force, ForceMode.Acceleration);
            rigidbody.AddForce(gravity, ForceMode.Acceleration);

        } else {
            groundNormal = Vector3.up;

            Vector3 gravity = -groundNormal * fallGravity;
            rigidbody.AddForce(-gravity, ForceMode.Acceleration);
        }

        Vector3 projection = Vector3.ProjectOnPlane(transform.forward, groundNormal);
        Quaternion rotation = Quaternion.LookRotation(projection, groundNormal);

        rigidbody.MoveRotation(Quaternion.Lerp(rigidbody.rotation, rotation, Time.deltaTime * 10f));
        //HAce la rotacion de la nave mas cinematica
        float angle = angleOfRoll * -input.rudder;
        Quaternion bodyRotation = transform.rotation * Quaternion.Euler(0f, 0f, angle);
        shipBody.rotation = Quaternion.Lerp(shipBody.rotation, bodyRotation, Time.deltaTime * 10f);
    }

        void CalculatePropulsion() {
            float rotationTorque = input.rudder - rigidbody.angularVelocity.y;
            rigidbody.AddRelativeTorque(0f, rotationTorque, 0f, ForceMode.VelocityChange);

            float sidewaySpeed = Vector3.Dot(rigidbody.velocity, transform.right);

            Vector3 sideFriction = -transform.right * (sidewaySpeed / Time.fixedDeltaTime);

            rigidbody.AddForce(sideFriction, ForceMode.Acceleration);

            if (input.thruster <= 0f)
                rigidbody.velocity *= slowingVelFactor;

            if (!isOnGround)
                return;
            if (input.isBraking)
                rigidbody.velocity *= brakingVelFactor;
            float propulsion = driveForce * input.thruster - drag * Mathf.Clamp(speed, 0f, terminalVelocity);
            rigidbody.AddForce(transform.forward * propulsion, ForceMode.Acceleration);

        }
        void OnCollisionStay(Collision collision) {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Wall")) {

                Vector3 upwardForceFromCollision = Vector3.Dot(collision.impulse, transform.up) * transform.up;
                rigidbody.AddForce(-upwardForceFromCollision, ForceMode.Impulse);
            }
        }
        public float GetSpeedPercentage() {

        return rigidbody.velocity.magnitude / terminalVelocity;
    }
        

}


