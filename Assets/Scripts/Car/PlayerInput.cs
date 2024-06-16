using Simplon;
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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          rudder= Input.GetAxis("Horizontal");
         thruster = Input.GetAxis("Vertical");
        isBraking = Input.GetButton("Brake");
                Debug.Log(isBraking);
        if (animator != null) {
            // Conditionally set the trigger based on the value of isBraking
            if (isBraking && !animator.GetBool("OnBreakingMode")) {
                animator.SetTrigger("BreakingOn");
                animator.SetBool("OnBreakingMode", true);
            } 
            if (!isBraking && animator.GetBool("OnBreakingMode")) {
                animator.SetTrigger("BreakingOff");
                animator.SetBool("OnBreakingMode", false);
                Debug.Log("APago freno");

            }
            animator.SetInteger("Speed", GameControler.instance.ObtnerSpeed());
        } else {
            Debug.LogError("Animator component not found.");
        }
    }
    
}
