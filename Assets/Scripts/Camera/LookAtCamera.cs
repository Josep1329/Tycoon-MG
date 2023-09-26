using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform mainCamera;
    void Start()
    {
        //Conseguir el transform de la camara principal
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Miramos hacia la camara
        transform.LookAt(mainCamera);
    }
}
