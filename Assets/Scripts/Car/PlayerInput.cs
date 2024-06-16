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

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
          rudder= Input.GetAxis("Horizontal");
         thruster = Input.GetAxis("Vertical");
        isBraking = Input.GetButton("Brake");
    }
    
}
