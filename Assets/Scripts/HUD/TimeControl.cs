using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Simplon;
/*la funcion de este script es*/

public class TimeControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoTemporizador; // Referencia al objeto TextMeshProUGUI
    [SerializeField] private float tiempoRestante = 60f; // Temporizador de 60 segundos (puedes ajustar este valor)
    private float tiempoActual;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = tiempoRestante;
    }

    // Update is called once per frame
    void Update()
    {
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
            // si se termina el tiempo mostrar pantalla de muerte
            //y volver al inicio
            GameControler.instance.pasarNivel("Race1");
        }
    }

    public void ResetearTiempoVuelta() {
        //reestablece el tiempo al lso segundos iniciales
        tiempoActual = tiempoRestante;
    }
}

