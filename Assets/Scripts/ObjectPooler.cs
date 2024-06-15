using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

public class ObjectPoolItem {
    public GameObject objectToPool; //Objeto a instanciar
    public int amountToPool;        //Cantidad de objetos a instanciar
    public bool shouldExpand;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<ObjectPoolItem> itemsToPool; //Objetos que quiero instanciar
    public List<GameObject> pooledObjects;   //Lista que guarda los objetos instanciados

    void Awake() {
        SharedInstance = this;
    }

    void Start() {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag)) {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool) {
            if (item.objectToPool.CompareTag(tag)) {
                if (item.shouldExpand) {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}