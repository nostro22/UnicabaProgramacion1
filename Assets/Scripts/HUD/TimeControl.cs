using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Simplon;
using UnityEngine.UI;
/*la funcion de este script es*/

public class TimeControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoTemporizador; // Referencia al objeto TextMeshProUGUI
    [SerializeField] private float tiempoRestante = 60f; // Temporizador de 60 segundos (puedes ajustar este valor)
    [SerializeField] private Slider slider;
    private float tiempoActual;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = tiempoRestante;
        slider.maxValue = tiempoRestante;
    }

    // Update is called once per frame
    void Update()
    {
        MostrarTiempo();
        slider.value = tiempoActual;
    }

    public void ResetearTiempoVuelta() {
        //reestablece el tiempo al los segundos iniciales
        tiempoActual = tiempoRestante;
    }

    private void MostrarTiempo()
    {
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
                GameControler.Instance.ResetCombustible();
                GameControler.Instance.pasarNivel("Race1");
            }

        }
    }

    public void Reset_TimeControler()
    {

        tiempoActual = tiempoRestante;
    }

    public void AddTime(float Seg)
    {
        //sumar tiempo extra
        tiempoActual += Seg;
    }
}

