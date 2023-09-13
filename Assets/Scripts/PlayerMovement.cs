using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //Variables publicas
    public float walkSpeed, runSpeed;
    public bool canMove;

    // Variables privadas
    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent <CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            walk();
            Run();
        }
        Gravity();

    }

    void walk()
    {
        // Conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        // Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Movemos al player
        characterController.Move(vectorMovement * speed * Time.deltaTime);
    }

    // Funcion para correr
    void Run()
    {
        //Si presionamos el boton para correr modificmos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }

}
