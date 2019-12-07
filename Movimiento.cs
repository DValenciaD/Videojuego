using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Esteblece y controla los movientos del objeto

public class Movimiento : MonoBehaviour
{
    [Header("Visual")] // Es el objeto vacio
    public GameObject model;
    public string[] tipoAtaque;
    public bool movimientoAtaque;
    
    public int cont;
    Animator anim;
    float velocidad;
    float velocidadLateral;
    float rotationSpeed = 2f; // Velocidad que va a tomar

    Quaternion targetModelRotation; // Almacena el valor incial de ángulo del objeto


    void Start()
    {
        movimientoAtaque = false; //"movimientoAtaque" inicia siendo falso
        cont = 0; //Elegir indice de automatizacion de ataque
        anim = GetComponent<Animator>();
        velocidad = 6;
        velocidadLateral = 6;

        targetModelRotation = Quaternion.Euler(0, 0, 0); // Guarda sistema de rotación, ángulo que tengo inicialmente El punto de vista al que tiene que ver inicialmente 
    }

    // Update is called once per frame
    void Update()
    {
        ControlGeneralMovimiento(); //Se ejecuta el metodo " ControlGeneralMovimiento"
        Ataque(tipoAtaque[cont]);
        CambioAtaque();
    }

    void ControlGeneralMovimiento()
    {
        if (Input.GetKey(KeyCode.Q)) 
        {
            movimientoAtaque = true; //Entonces "movimientoAtaque" es verdadero
        }
        else //De lo contrario
        {
            movimientoAtaque = false; //"movimientoAtaque" es falso
        }

        if (movimientoAtaque == false) //Si "movimientoAtaque" es falso
        {
            anim.SetLayerWeight(0, 1);
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(2, 0);

            ControlMovimiento(); //Se ejecuta el método "ControlMovimeinto"
        }
        else if (movimientoAtaque == true)
        {
            anim.SetLayerWeight(0, 0); //Indice parametro izquierdo, peso parámetro derecho (va de 0, 0.5, hasta 1)
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(2, 1);

            ControlMovimientoAtaque();
        }
    }

    
    void ControlMovimiento()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);

        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotationSpeed);

        transform.Translate(direccion);
        anim.SetFloat("Velocidad", vertical * velocidad);
        anim.SetFloat("VelocidadLateral", horizontal * velocidadLateral);
        direccion.Normalize();

        if (direccion.z > 0) // Si el valor es mayor que 0 va al frente
        {
            targetModelRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion.z < 0) // Si el valor es mayor que 0 va a atras 
        {
            targetModelRotation = Quaternion.Euler(0, 180, 0);
        }

        if (direccion.x > 0) // Si el valor es mayor que 0 va a la izquiera
        {
            targetModelRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direccion.x < 0) // Si el valor es menor que 0' se desplaza a la izquiera
        {
            targetModelRotation = Quaternion.Euler(0, 270, 0);
        }
    }
    
    void ControlMovimientoAtaque()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);

        /*model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotationSpeed);*/ // Lerp = Interpolación o unión, hace una iterpolación entre dos ángulos del tipo quaternion, toma como base, primer dato toma la ultima delctura de giro; el siguiente dato es hacia donde o hasta dónde quiero llegar, por eso es el targetModelRotation; el ultimo espacio es la velocidad, 
                                                                                                                                   // Time.deltaTime refresca los cuadros a una lectura específica, cuando se refrescan los cuadros se acelera la imagen 
        transform.Translate(direccion);
        anim.SetFloat("velocidadAtaqueFrontal", vertical * velocidad);
        anim.SetFloat("velocidadAtaqueLateral", horizontal * velocidadLateral);
        direccion.Normalize(); //Agusta la lectura de dirrecion en un valor entre 0 y 1, para estabilizar condiciones que vienen abajo 
    }

    void Ataque(string tipoAtaque)
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool(tipoAtaque, true); //Pasa el valor booleano a un Animator Controller
        }
        else
        {
            anim.SetBool(tipoAtaque, false);
        }
    }

    void Ataque(int cont, string contText)
    {
        anim.SetInteger(contText, cont); //Establece el valor del prámetro entero dado
    }

    void CambioAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cont++;
            if (cont > tipoAtaque.Length - 1) //De la extension del array se tiene que leer los tres espacios
            {
                cont = 0;
            }
        }
    }
}
