using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Crea todo el movimiento del personaje y la detección de piso 

public class BaseMove : MonoBehaviour
{
    public float velocidad;
    public float velRot;
    public bool onRotation = false;
    protected Rigidbody rb;
    protected Animator anim;
    protected float horizontal;
    protected float vertical;
    protected float mouseHorizontal;

    protected void AccesoComponentes()
    {
        rb = GetComponent<Rigidbody>(); //"rb" es igual al rigidbody
        anim = GetComponent<Animator>(); //"anim" es igual al animator
    }

    protected void Aceleracion(float v)
    {
        horizontal = Input.GetAxis("Horizontal") * v * Time.deltaTime; // Permite mover al onjeto horizontalmente
        vertical = Input.GetAxis("Vertical") * v * Time.deltaTime; // Permite mover al onjeto verticalmente

        rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical);

        anim.SetFloat("Velocidad", vertical); //Declara la velocidad vertical
        anim.SetFloat("Horizontal", horizontal); //Declara la velocidad horizontal
    } 

    protected void Rotacion(float r)
    {
        mouseHorizontal = Input.GetAxis("Mouse X") * r * Time.deltaTime;
        rb.AddRelativeTorque(rb.transform.up * mouseHorizontal);

        //var angle = transform.localEulerAngles.y;
        //angle = (angle > 180) ? angle - 360 : angle;

        float angle = transform.localEulerAngles.y; //Tranforma los el ángulo en ángulos Euler en y

        if (transform.localEulerAngles.y > 90 && transform.localEulerAngles.y <180) //Si es mayor que 90 y menor que 180
        {
            onRotation = true; //"onRotation" es verdadero
            Debug.Log("Estoy rotando");
        }

        if (angle > 180) //Si el ángulo es menor que 180
        {
            angle -= 360; //El ángulo es igual a -360

            if (angle < -90) //Si el angulo es mayor a -90
            {
                onRotation = true; //"onRotation" es verdadero
                Debug.Log("Estoy rotando pal' otro lado");
            }
        }

        if (onRotation == true) // Si la rotación es igual a true
        {
            transform.localEulerAngles = Vector3.zero * Time.time * 0.1f; 
            onRotation = false; //"onRotation" es falso
        }
    }

    #region Comprobacion terreno
    public LayerMask mask;
    protected bool isGrounded()
    {
        Vector3 rayOrigin = GetComponent<Collider>().bounds.center; //Declara el origen del rayo
        float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.01f; //Declara la distancia del rayo
        Ray ray = new Ray(); //Se crea un rayo
        ray.origin = rayOrigin; //El origen del rayo es igual a "rayOrigin"
        ray.direction = Vector3.down; //Declara la dirección del rayo
        Debug.DrawRay(ray.origin, ray.direction, Color.red); //Crea un rayo desde el origen asignado en la dirección asignada

        if (Physics.Raycast(ray.origin, ray.direction, rayDistance, mask)) //Detecta la colisión de un objeto hacia el terreno para generar una acción
        {
            Debug.Log("Está chocando");
            return true; //Retorna verdadero
        }
        else
        {
            return false; //Retorna falso
        }
        #endregion
    }

}
