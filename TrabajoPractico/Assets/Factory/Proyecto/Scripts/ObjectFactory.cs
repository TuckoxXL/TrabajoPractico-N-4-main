using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private Factory[] factory;
    private Dictionary<string, Factory> objectName;

    private void Awake()
    {
        objectName = new Dictionary<string, Factory>();
        foreach (var stuff in factory)
        {
            objectName.Add(stuff.Name, stuff);
        }
    }

    public Factory CreateStuff(string objName, Transform playerTransform)
    {
        if (objectName.TryGetValue(objName, out Factory Prefab))
        {
            Factory objectinstance = Instantiate(Prefab, playerTransform.position, Quaternion.identity); 
            return objectinstance;
        }
        else 
        {
            Debug.LogWarning($"El objecto '{objectName}' no existe en la base de datos."); 
            return null; 
        }
    }
}
