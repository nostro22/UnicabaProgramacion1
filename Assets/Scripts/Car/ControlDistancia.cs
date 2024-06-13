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

    //Obtengo la instancia del game manager
    //private GameControler Controler = GameControler.Instance;

    void Start()

    {
        // Inicializar la posición anterior con la posición inicial del objeto
        posicionAnterior = transform.position;
        distanciaTotalRecorrida = 0f;
        control = 0f;
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
        GameControler.Instance.distancia = distanciaTotalRecorrida;

       if (control > 1) {
            //si recorio mas de 1 metro restar combustible
            //resetear la variable conbtrol
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

    private void QuitarCombustible() { 
    
    }
}
