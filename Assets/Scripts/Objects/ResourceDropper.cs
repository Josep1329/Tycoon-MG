using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    public GameObject[] resources;
    public float spawnTime;

    private int dropperTier;
     

    void Start()
    {
        //inicial variables
        dropperTier = 1;
        InvokeRepeating("DropResource", spawnTime, 1f);
    }

    //Funcion para instanciar un recurso
    void DropResource()
    {
        if (resources[dropperTier - 1] != null || dropperTier <= resources.Length)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        }
        
    }

    //funcion para mejorar le dropper

public void UpgradeDropper()
    {
        dropperTier++;
    }
}
