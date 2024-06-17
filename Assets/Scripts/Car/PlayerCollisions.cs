using Simplon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{   
    //Se asigna al serializable un objeto en scena vacio como punto default de iniciacion
    [SerializeField]Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        //Si el jugador muere lo transportamos al ultimo punto de respawn 
        if (other.gameObject.CompareTag("Death")) {
            Respawn();
        }
        //Actualizamos el punto de respawn 
        if (other.gameObject.CompareTag("Respawn")) {
            RespawnSystem respawn = other.GetComponent<RespawnSystem>();
            if (respawn != null) {
                respawnPoint = respawn.GetRespawnPoint();
            }
        }
    }

     void OnCollisionEnter(Collision collision) {
        //Si el jugador muere lo transportamos al ultimo punto de respawn 
        if (collision.gameObject.CompareTag("BallOfDeath")) {
            Respawn();
        }
    }

    void Respawn() {
        this.gameObject.transform.position = respawnPoint.position;
        this.gameObject.transform.rotation = respawnPoint.rotation;
        GameControler.Instance.Life--;
    }

}
