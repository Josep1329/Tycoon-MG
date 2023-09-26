using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Variables publicas
    public float sensibility;
    public Transform cameraJointY, targetObject;
    public bool canRotate;

    //variables privadas
    private float xRotation, yRotation;


    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si podemos rotar
        if (canRotate)
        {
            Rotate();
        }

        FollowTarget();
    }
    //funcion para rotar
    void Rotate()
    {
        //Conseguimos los inputs del mouse
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        xRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        //POnemos limitacion al eke y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //Rotamos los componentes X y Y
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }
    //funcion para seguir al objetivo
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
