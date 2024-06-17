using Simplon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelojControl : MonoBehaviour
{
    [SerializeField] private float TiempoExtra=5f;

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInput Auto = other.GetComponent<PlayerInput>();
        TimeControl control_tiempo = FindObjectOfType<TimeControl>();

        if (Auto != null)
        {
            control_tiempo.AddTime(TiempoExtra);
            Destroy(this.gameObject);
            //Debug.Log("choque con reloj");
        }
    }
}
