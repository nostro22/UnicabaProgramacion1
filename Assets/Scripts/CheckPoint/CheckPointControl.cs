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
    [SerializeField] private bool CheckpointEnter = false;//indica si ya se paso por ese check Point
    [SerializeField] private int IdCheckPoint = 1;//numero para identificar checkpoint si hay mas de uno
    [SerializeField] private bool IsGoal = false;//indica si este check point es la meta si se setea a true 
    private GameControler Controller;

    private void Start()
    {
        Controller = GameControler.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInput Auto = other.GetComponent<PlayerInput>();
       
        //buscar el componente HudControl para manejar el tiempo
        HUdControl control_tiempo =FindObjectOfType<HUdControl>();

        if (Auto != null)
        {
            if (!CheckpointEnter)
            {
                //indica si ya se paso por ese check Point
                CheckpointEnter = true;
                //resetear el tiempo
                control_tiempo.Reset_TimeControler();
                //reset combustible
                Controller.ResetCombustible();
               
            }
            //controal para evitar que retrocediendo hacia la meta se cuente una vuelta
            if (Checks_Activados())
            {

                if (IsGoal && Controller.Obtener_vuelta() == Controller.Obtener_totalVueltas())
                {
                    //si es la meta y se completaron todas las vueltas pasa de nivel
                    Controller.ResetVariables();
                    Controller.pasarNivel("Race2");
                }
                else if (IsGoal && Controller.Obtener_vuelta() < Controller.Obtener_totalVueltas())
                {
                    //si aun faltan vueltas y paso por la meta se reestablecen las variables
                    //CheckPointEnter a false para la siguiente vuelta
                    ResetAllCheckpoints();
                    //agregar vuelta al contador
                    Controller.Sumar_vuelta();
                }

            }

        }


    }

    
    private void ResetAllCheckpoints()
    {
        // M�todo para restablecer todos los checkpoints
        // Encuentra todas las instancias de CheckPointControl en la escena
        CheckPointControl[] allCheckpoints = FindObjectsOfType<CheckPointControl>();

        // Recorre todas las instancias y restablece CheckpointEnter a false
        foreach (CheckPointControl checkpoint in allCheckpoints)
        {
            checkpoint.CheckpointEnter = false;
        }

        // Opcionalmente, se puede volver a establecer el checkpoint actual a true
        //de ser necesario
        //CheckpointEnter = true;
    }

    
    private bool Checks_Activados() {
        //metodo para controlar  el estado de los checkpoint
        //devuelve true si todos los checkpoint fueron cruzados
        //caso contrario devuelve false

        int control = 0;
        // Encuentra todas las instancias de CheckPointControl en la escena

        CheckPointControl[] allCheckpoints = FindObjectsOfType<CheckPointControl>();

        //resto 1 para no contar la meta
        int Total_checkP =allCheckpoints.Length - 1;

        // recorre todas las instancias checkpoint
        foreach (CheckPointControl checkpoint in allCheckpoints)
        {
            if (!checkpoint.CheckpointEnter && !checkpoint.IsGoal) { 
                //busca los checkpoints por donde no paso aun, que no sean la meta
                control++;
            }
        }
       /* Debug.Log("total de checkpoits contados en ele bucle: "+control);
        Debug.Log("total de checkpoits: " + Total_checkP);*/

        if (Total_checkP == control)
        {   
            //no paso por ningun checkpoint aun
            return false;
        }
        else { 
            // paso por lo menos por un checkpoint
            return true;
        }
    }
}
