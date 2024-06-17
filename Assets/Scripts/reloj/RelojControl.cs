using Simplon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelojControl : MonoBehaviour
{
    [SerializeField] private float TiempoExtra=5f;
    private PlayerInput Auto ;
    private TimeControl control_tiempo ;

   

    private void Start()
    {
        control_tiempo = FindObjectOfType<TimeControl>();
       
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Auto = other.GetComponent<PlayerInput>();
     
        if (Auto != null)
        {//agreagr tiempo extra y destrir el reloj 
            control_tiempo.AddTime(TiempoExtra);
            Destroy(gameObject);
            
        }
    }

  
}
