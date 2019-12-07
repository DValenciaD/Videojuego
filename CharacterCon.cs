using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Se crea todo lo que controlará al objeto (ataques, salto, direcciones, etc.)

public class CharacterCon : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Animator anim;
    private bool ataque;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); //Declara en controlador
        anim = GetComponentInChildren<Animator>(); //Declara el animator
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded) //Si en controlador está en el piso 
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed; //moveDirection es igual a la dirección por la velocidad

            if (Input.GetButton("Jump")) //Si se aprienta el boton "Jump"
            {
                moveDirection.y = jumpSpeed; //La dirección del movimiento es igual a la velocidad del salto
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)

        moveDirection.y -= gravity * Time.deltaTime; // La dirección del movimiento en y es igual menos la gravedad 

        //Mover controlador

        characterController.Move(moveDirection * Time.deltaTime);

        if (moveDirection.z  <= 0 || transform.rotation.y <= -90 || transform.rotation.y >= 90) //Si la dirección en z en menor igaul que 0, o la rotación en y es menor o igual que -90, o la rotación en y es mayor igual que 90 
        {
            moveDirection.z *= -speed; //La dirección en z es igual a la direccion por -velocidad
            anim.SetFloat("Speed", moveDirection.z * speed);
        }

        anim.SetFloat("Speed", moveDirection.z * speed); //

        if (Input.GetKey(KeyCode.LeftShift)) //Si se aprieta la tecla izquiera
        {
            anim.SetLayerWeight(1, 1); //Establece el peso de la capa en el índice dado, el primero es la capa indice y el segundo el nuevo peso de la capa
            anim.SetFloat("Run", 0); //Envia valores flotantes al animator para efectuar las transiciones
        }

        AtaqueNormal(); //Ejecuta el metodo "AtaqueNormal"
    }

    void AtaqueNormal()
    {
        if (Input.GetMouseButtonDown(0)) //Si presiona el boton primario
        {
            ataque = true; //entonces "ataque" es verdadero
        }
        else //De lo contrario
        {
            ataque = false; //"ataque" es falso
        }

        anim.SetBool("AttackNormal", ataque); //<envía el booleano "ataque" al animator para que se ejecute la animacion "AttackNormal1"
    }

    
}
