using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Death")) {

            this.gameObject.transform.position = respawnPoint.position;
            this.gameObject.transform.rotation = respawnPoint.rotation;

        }
        if (other.gameObject.CompareTag("Respawn")) {
            RespawnSystem respawn = other.GetComponent<RespawnSystem>();
            if (respawn != null) {
                respawnPoint = respawn.GetRespawnPoint();
            }
        }
    }

    void Respawn() { 
    
    }
}
