using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Hace que el objeto vea a la posición del objeto

public class Look : MonoBehaviour
{
    public Transform look;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(look); //Gira el transform para que el vector hacia adelante apunte en la posición actual del target
    }
}
