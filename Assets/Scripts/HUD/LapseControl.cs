using UnityEngine;
using Simplon;
using TMPro;
/*codigo para mostrar en pantalla la informacion sobre las vueltas*/
public class LapseControl : MonoBehaviour
{
    //t_vueltas es para mostrar el numero de vueltas totales
    //Vuelta_A es para mostrar la vuelta actual
    [SerializeField] private TextMeshProUGUI T_vueltas,Vuelta_A;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //muestra en que vuelta esta, en el hud
        Vuelta_A.text = string.Format("{0}", GameControler.instance.Obtener_vuelta());
        //muestra la cantida vueltas para ganar en el hud
        T_vueltas.text = string.Format("{0}", GameControler.instance.Obtener_totalVueltas());
    }
}
