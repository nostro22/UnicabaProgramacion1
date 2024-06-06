using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Simplon;

/*La funcion de este script es detectar la colision del auto con el checkpoint
 en la variable CheckPointEnter se indica que ya se paso por ese checkpoint
tambien se puede usar apra desactivar un checkpoint
IsGoal indica si ese checkpoint se comporta como meta*/
public class CheckPointControl : MonoBehaviour
{
    [SerializeField] private bool CheckpointEnter=false;//indica si ya se paso por ese check Point
    [SerializeField] private int IdCheckPoint=1;//numero para identificar checkpoint si hay mas de uno
    [SerializeField] private bool IsGoal=false;//indica si este check point es la meta si se setea a true 

 
    private void OnTriggerEnter(Collider other)
    {
        PlayerInput Auto= other.GetComponent<PlayerInput>();

        if (Auto != null && !CheckpointEnter) {
            CheckpointEnter = true;
            Debug.Log("Pasaste por el Check point Nro "+ IdCheckPoint);
        }
        if (Auto != null && IsGoal) {
            var controlador= GameControler.instance;
            controlador.pasarNivel("Race2");
        }
        
    }
}
