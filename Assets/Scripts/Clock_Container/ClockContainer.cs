using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockContainer : MonoBehaviour
{
    // El prefab del Clock a instanciar
    [SerializeField] private GameObject clockPrefab;

    private Transform[] subcontainers;

    // Start is called before the first frame update
    void Start()
    {
        //inicializar las posiciones
        Ini_instanciasClock();
    }

    private void Ini_instanciasClock()
    {
        // Obtener todas las referencias a los subcontenedores de los Clock's

        subcontainers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            subcontainers[i] = transform.GetChild(i);
        }
    }

    public void ReinstantiateClocks()
    {//instandia los clock en sus contenedores nuevamente

        foreach (Transform subcontainer in subcontainers)
        {
            // Verificar si el Clock ha sido destruido
            if (subcontainer.childCount == 0)
            {
                // Instanciar un nuevo Clock en el subcontenedor
                Instantiate(clockPrefab, subcontainer);
            }
        }
    }
}
