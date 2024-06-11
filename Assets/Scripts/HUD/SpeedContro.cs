using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplon;
using TMPro;
/*este script es el encargado de mostrar la velocidad del vehiculo en la vista del HuD*/
public class SpeedContro : MonoBehaviour
{
    //referencia al text donde se mostrara la velocidad tiene que ser un textmeshpro-textUI
    [SerializeField] private TextMeshProUGUI SpeedViewer;

    // Update is called once per frame
    void Update()
    {
        mostrarSpeed(); 
    }
    private void mostrarSpeed() {
        //muestra la velocidad 
        SpeedViewer.text = string.Format("{0}", GameControler.instance.ObtnerSpeed());
    }
}
