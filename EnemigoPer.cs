using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Persigue al jugador

public class EnemigoPer : Persecucion //Hereda a EnemigoPer
{
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //La posición del jugador es igual al objeto con la etiqueta "Player"
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir(playerPosition, this.gameObject.transform); //Se dirije a la posicion del jugador
    }
}
