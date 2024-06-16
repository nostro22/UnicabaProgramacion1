using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShooter : MonoBehaviour
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ShooterOn());
        StartCoroutine(MoveCoroutine());

    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShooterOn() {
        while (true) {
            GameObject ball = ObjectPooler.SharedInstance.GetPooledObject("BallOfDeath");
            if (ball != null) {
                ball.transform.SetPositionAndRotation(transform.position, transform.rotation);
                ball.SetActive(true);
                audioSource.Play();
            }
           yield return new WaitForSeconds(1);
        }
    }
    IEnumerator MoveCoroutine() {
        while (true) {
            // Calcular la distancia entre las dos posiciones
            Vector3 direction = (position2.position - position1.position).normalized;

            // Mover el objeto hacia position1
            while ((transform.position - position1.position).magnitude > 0.01f) {
                transform.position = Vector3.MoveTowards(transform.position, position1.position, Time.deltaTime * 5f);
                yield return null;
            }

            // Esperar un poco antes de comenzar a mover hacia position2
            yield return new WaitForSeconds(0.1f);

            // Mover el objeto hacia position2
            while ((transform.position - position2.position).magnitude > 0.01f) {
                transform.position = Vector3.MoveTowards(transform.position, position2.position, Time.deltaTime * 5f);
                yield return null;
            }

            // Esperar un poco antes de comenzar el próximo ciclo
            yield return new WaitForSeconds(0.1f);
        }
    }
}
