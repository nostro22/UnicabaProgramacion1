using Simplon;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{   
    //Se asigna al serializable un objeto en scena vacio como punto default de iniciacion
    [SerializeField]Transform respawnPoint;
  
    private void OnTriggerEnter(Collider other) {
        //Si el jugador muere lo transportamos al ultimo punto de respawn 
        if (other.gameObject.CompareTag("Death")) {
            RespawnPlayer();
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
            RespawnPlayer();
        }
     }

    private void RespawnPlayer() {
        this.gameObject.transform.position = respawnPoint.position;
        this.gameObject.transform.rotation = respawnPoint.rotation;
        GameControler.Instance.Life--;
    }

}
