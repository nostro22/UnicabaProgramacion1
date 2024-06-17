using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplon;

public class FuelControler : MonoBehaviour
{
    private GameControler Controler;
    private BoxCollider colliderGas;
    private MeshRenderer rendererGas;

    [SerializeField] private float SumarCombustible=50f;
    // Start is called before the first frame update
    void Start()
    {
        Controler= GameControler.Instance;
        colliderGas = GetComponent<BoxCollider>();
        rendererGas = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInput Auto = other.GetComponent<PlayerInput>();
        

        if (Auto != null)
        {
            Controler.Combustible += SumarCombustible;
            StartCoroutine(OnPlayerGrab());
            //Debug.Log("choque con reloj");
        }
    }

    IEnumerator OnPlayerGrab() {
        rendererGas.enabled=false;
        colliderGas.enabled=false;
        yield return new WaitForSeconds(10);
        rendererGas.enabled = true;
        colliderGas.enabled = true;
    }

}
