using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //Variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public GroundDetector groundDetector;


    // Variables privadas
    private Vector3 vectorMovement, verticalForce;
    private float speed, currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent <CharacterController>();
        speed = 0f;
        currentSpeed = 0f;
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            walk();
            Run();
            AlignPlayer();
            Jump();
        }
        Gravity();
        CheckGround();
    }

    void walk()
    {
        // Conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        // Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Nos movemos en direccion a la camera
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        //Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * speed, 10f * Time.deltaTime);

        //Movemos al player
        characterController.Move(vectorMovement * currentSpeed * Time.deltaTime);
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


    void Jump()
    {
        if(isGrounded && Input.GetAxis("Jump") > 0f)
        {
            
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    void Gravity()
    {
        if (!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2f, 0f);
        }

        Debug.Log(verticalForce);
        characterController.Move(verticalForce * Time.deltaTime);
    }

    void AlignPlayer()
    {
        //Si nos estamos moviendo, alineamos la rotacion
        if(characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }

    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
        
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}
