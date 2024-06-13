using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplon;
using TMPro;
using System;

public class HUdControl : MonoBehaviour
{
    //t_vueltas es para mostrar el numero de vueltas totales
    //Vuelta_A es para mostrar la vuelta actual
    [SerializeField] private TextMeshProUGUI T_vueltas, Vuelta_A;

    //referencia al text donde se mostrara la velocidad tiene que ser un textmeshpro-textUI
    [SerializeField] private TextMeshProUGUI SpeedViewer;

    // Referencia al objeto TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI textoTemporizador;

    // Temporizador de 60 segundos (puedes ajustar este valor)
    [SerializeField] private float tiempoRestante = 60f;

    //referencia al texbox para mostrar la distancia, y la vida
    [SerializeField] private TextMeshProUGUI VisorDistancia,VisorVida;

    private float tiempoActual;

    //Obtengo la instancia del game manager
    //var Controler= GameControler.Instance;

    // Start is called before the first frame update
    void Start()
    {
        Reset_TimeControler();

    }

    // Update is called once per frame
    void Update()
    {
        //muestra en que vuelta esta, en el hud
        Vuelta_A.text = string.Format("{0}", GameControler.Instance.Obtener_vuelta());
        //Vuelta_A.text = string.Format("{0}", Controler.Obtener_totalVueltas());

        //muestra la cantida vueltas para ganar en el hud
        T_vueltas.text = string.Format("{0}", GameControler.Instance.Obtener_totalVueltas());
        //T_vueltas.text = string.Format("{0}", Controler.Obtener_totalVueltas());

        //mostrar la velocidad
        mostrarSpeed();
        //mostrar el tiempo si se termina rinicia
        MostrarTiempo();
        //mostrar distancia recorrida
        MostrarDistancia();
        //mostrar las vidas disponibles
        MostrarVida();
    }

    //
    /*-----------------------------------*/
    //

    private void mostrarSpeed()
    {
        //muestra la velocidad 
        SpeedViewer.text = string.Format("{0}", GameControler.Instance.ObtnerSpeed());
    }

    private void MostrarTiempo() {
        //muestra el tiempo en el hud y si se termina rinicia la carrera
        if (tiempoActual > 0)
        {
            //muestra una cuenta regresiva en el control de texto refernciado
            tiempoActual -= Time.deltaTime;
            int minutos = Mathf.FloorToInt(tiempoActual / 60f);
            int segundos = Mathf.FloorToInt(tiempoActual % 60f);
            int centesimas = Mathf.FloorToInt((tiempoActual * 100) % 100);
            textoTemporizador.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);


        }
        else
        {
            textoTemporizador.text = "00:00:00";
           
            if (GameControler.Instance.Life > 1)
            {
                //si aun tiene vidas se resta 1
                GameControler.Instance.Life--;
                //y se resetea el tiempo
                Reset_TimeControler();
            }
            else
            {
                // si se termina el y la vida tiempo mostrar pantalla de muerte
                //y volver al inicio
                GameControler.Instance.pasarNivel("Race1"); 
            }
        
        }
    }

    private void MostrarDistancia() { 
        //VisorDistancia.text=string.Format("{0,00}", Controler.MostrarDistancia());
        VisorDistancia.text=Math.Round(GameControler.Instance.distancia, 2,MidpointRounding.AwayFromZero).ToString();
        Debug.Log("distancia: " + GameControler.Instance.distancia);
    }

    private void MostrarVida() {
        VisorVida.text = GameControler.Instance.Life.ToString();
    }
    private void Reset_TimeControler() {

        tiempoActual = tiempoRestante;
    }
    
    

}
