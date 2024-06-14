using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rb;

    public string verticalAxisName = "Vertical";
    public string horizontalAxisName = "Horizontal";
    public string brakingKey = "Brake";
    //Vertical
    public float thruster;
    //Horizontal
    public float rudder;
    public bool isBraking;
    private Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          rudder= Input.GetAxis("Horizontal");
         thruster = Input.GetAxis("Vertical");
        isBraking = Input.GetButton("Brake");
        controller.SetBool("isBrakingAnimator",isBraking);
    }
    
}
