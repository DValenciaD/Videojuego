using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Accede a los datos del enemigo y agrega valores

public class CrearEnemigo : MonoBehaviour
{
    //Crear jerarquia
    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    EnemigoB enemigoB; 

    // Start is called before the first frame update
    void Start()
    {
        enemigoB = FindObjectOfType<EnemigoB>(); //Accede a todos los datos de "enemigoB"
        BusquedaEnemigo(Id); //Va a leer un sistema de búsqueda
    }

    private void BusquedaEnemigo(string id)
    {
        for (int i = 0; i < enemigoB.enemigo.Count; i++) //De la base de datos del enemigo, lee los objetos de la lista
        {
            if (id == enemigoB.enemigo[i].nombre) //Si se encuentra el dato del bloque, eonces a la variable se le agregan los valores siguientes
            {
                nombre = enemigoB.enemigo[i].nombre;
                vida = enemigoB.enemigo[i].vida;
                magia = enemigoB.enemigo[i].magia;

            }
        }
    }
}
