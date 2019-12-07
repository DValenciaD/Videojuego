using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    // Daniela Itzel Valencia Durán
    // Programación Orientada a Objetos
    // Josue Israel Rivas Díaz
    // Genera daño en el objeto

    CEnemigo dañoEnemigo;

    public string etiqueta; // lo vuelve accesible

    // Start is called before the first frame update
    void Start()
    {
        dañoEnemigo = GetComponentInParent<CEnemigo>(); //Encuentra un componente del tipo "CEnemigo" que esté vinculado al objeto o encapsulado a un elemento específico
        Debug.Log(dañoEnemigo.name);
    }

    // Update is called once per frame
    void Update()
    {
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        dañoEnemigo.vida -= 10;
    //    }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == etiqueta) //Si la etiqueta del objeto con el que colisiona es "etiqueta"
        {
            dañoEnemigo.vida -= 10; //Entonces quita 10 puntos a la vida
        }
    }
}
