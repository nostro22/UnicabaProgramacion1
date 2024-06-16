using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfDoomBehavior : MonoBehaviour
{
    private Rigidbody rb; // Referencia al componente Rigidbody

    private void Awake() {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody en el momento de la creación del objeto
    }

    private void OnEnable() {
        // Genera una fuerza aleatoria en la dirección forward del objeto
        float forceMagnitude = Random.Range(10f, 20f); // Define el rango de magnitud de la fuerza
        Vector3 forceVector = rb.transform.forward * forceMagnitude; // Calcula el vector de fuerza
        rb.AddForce(forceVector, ForceMode.Impulse); // Aplica la fuerza al objeto
        StartCoroutine(autoDisable());
    }

    IEnumerator autoDisable() {
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
