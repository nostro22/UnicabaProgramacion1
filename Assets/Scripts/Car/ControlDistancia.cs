using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplon;
/*Este script mide la distancia recorrida y dependiendo de la misma resta combustible
 si el combustible llega a 0 resta una vida*/
public class ControlDistancia : MonoBehaviour
{
    private Vector3 posicionAnterior;
    private float distanciaTotalRecorrida;
    float control;

    //configura el consumo de combustible para el auto
    [SerializeField] private float ConsumoCombustible=0.2f;

    //variable para la instancia del game manager
    private GameControler Controler;

    void Start()

    {
        // Inicializar la posición anterior con la posición inicial del objeto
        posicionAnterior = transform.position;
        distanciaTotalRecorrida = 0f;
        control = 0f;
        Controler = GameControler.Instance;
    }

    void Update()
    {
        // Calcular la distancia entre la posición anterior y la posición actual
        float distancia = Vector3.Distance(posicionAnterior, transform.position);
        control += distancia;

        // Sumar la distancia al total recorrido
        distanciaTotalRecorrida += distancia;

        // Actualizar la posición anterior
        posicionAnterior = transform.position;

        //Controler.Distancia = distanciaTotalRecorrida;
        Controler.distancia = distanciaTotalRecorrida;

       if (control > 1 ) {
            //si recorio mas de 1 metro restar combustible
            if (Controler.Combustible > 0)
            {
                QuitarCombustible(ConsumoCombustible);
            }
            else if(Controler.Life>1) { 
                Controler.Life--;
                Controler.ResetCombustible();
            }
            else
            {
                //perdio riniciar el juego
                Controler.pasarNivel("Race1");
            }

            //resetear la variable control
            control = 0;
        }
        // (Opcional) Mostrar la distancia total recorrida en la consola
        //Debug.Log("Distancia total recorrida: " + ((int)distanciaTotalRecorrida));
    }

    // Método público para obtener la distancia total recorrida
    public float ObtenerDistanciaTotalRecorrida()
    {
        return distanciaTotalRecorrida;
    }

    //metodo para descontar combustible a medida que se avanza
    private void QuitarCombustible(float restar) { 
        Controler.Combustible-=restar;
    }


}
