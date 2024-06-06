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


    private void OnTriggerEnter(Collider other)
    {
        PlayerInput Auto = other.GetComponent<PlayerInput>();
        var controller = GameControler.instance;
        //buscar el componente time control
        TimeControl control_tiempo =FindObjectOfType<TimeControl>();

        if (Auto != null)
        {
            if (!CheckpointEnter)
            {
                //indica si ya se paso por ese check Point
                CheckpointEnter = true;
                Debug.Log("vuelta " + controller.Obtener_vuelta() + " checkpoint nro: " + IdCheckPoint);
            }
            if (IsGoal && controller.Obtener_vuelta() == controller.Obtener_totalVueltas())
            {
                //si es la meta y se completaron todas las vueltas pasa de nivel
                var controlador = GameControler.instance;
                controlador.pasarNivel("Race2");
            }
            else if (IsGoal && controller.Obtener_vuelta() < controller.Obtener_totalVueltas())
            {
                //si aun faltan vueltas y paso por la meta se reestablecen las variables
                //CheckPointEnter a false para la siguiente vuelta
                ResetAllCheckpoints();
                //agregar vuelta al contador
                controller.Sumar_vuelta();
                //resetear el tiempo
                control_tiempo.ResetearTiempoVuelta();
            }


        }


    }

    // Método para restablecer todos los checkpoints
    private void ResetAllCheckpoints()
    {
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
}
