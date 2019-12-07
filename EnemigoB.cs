using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Crea la lista de los enemigos y agrega sus características

public class EnemigoB : MonoBehaviour
{
    public List<Enemigo> enemigo;

    void Awake() //Inicializa una variable antes de que comience el juego
    {
        enemigo.Add(new Enemigo(100, 50, "Hongo"));
        enemigo.Add(new Enemigo(200, 500, "Momia"));
        enemigo.Add(new Enemigo(50, 50, "Conejo"));
        enemigo.Add(new Enemigo(100, 1000, "CuboMalo"));
        enemigo.Add(new Enemigo(1000, 1000, "Huesos"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
