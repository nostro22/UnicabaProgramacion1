using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplon;

public class FuelControler : MonoBehaviour
{
    private GameControler Controler;

    [SerializeField] private float SumarCombustible=50f;
    // Start is called before the first frame update
    void Start()
    {
        Controler= GameControler.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInput Auto = other.GetComponent<PlayerInput>();
        

        if (Auto != null)
        {
            Controler.Combustible += SumarCombustible;
            Destroy(this.gameObject);
            //Debug.Log("choque con reloj");
        }
    }

}
