using UnityEngine;
using UnityEngine.SceneManagement;
/* este es el controlador del juego
 hasta el momento contola la carga de escenas y la velocidad del vehiculo*/
namespace Simplon {

    public  class GameControler : MonoBehaviour
    {
        public static GameControler Instance => instance;
        public static GameControler instance;
        private int Speed;
        //seteo las cantidad de vueltas por defect a 3
        [SerializeField] private int totalVueltas = 3;
        //guarda en que vuelta va la carrera
        private int vuelta_actual = 1;
        //inicializar
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else //Instance != null
            {
                Destroy(gameObject);
            }
        }
        //cambiar de a la pista2
        public void pasarNivel(string nombre)
        {
            //metodo para cambiar de nivel en el parametro nombre se indica el
            //nombre de la escena a cargar
            SceneManager.LoadScene(nombre);
        }
        public void agregarnEscena(string nombre)
        {
            //metodo para agregar una escena a la escena actual
            //En el parametro nombre se indica el
            //nombre de la escena a cargar
            SceneManager.LoadScene(nombre, LoadSceneMode.Additive);
        }
        public void actualizarSpeed(float speed)
        {
            //este metodo mantien actualizada la velocidad del auto
            //el parametro speed recibe un numero flotante y lo alamacena 
            //en la variable speed del GameControler
            Speed = Mathf.FloorToInt(speed * 100); // como la velocidad estaba en porcentaje multiplico por 100   
        }
        public int ObtnerSpeed()
        {
            //medoto que devuelve la velocidad indicada en la
            //variable Speed
            return Speed;
        }

        //suma 1 a la variable vuelta actual
        public void Sumar_vuelta() => vuelta_actual++;


        public int Obtener_vuelta()
        {
            //devuelve en que vualta va la carrera
            return vuelta_actual;
        }
        public void Setear_totalVueltas(int vueltas) { 
            //setea otro valor para el total de vueltas

            totalVueltas=vueltas; 
        }
        public int Obtener_totalVueltas() { 
            //devuelve el total de vueltas de la carrera
            return totalVueltas; ;
        }
    }


}

