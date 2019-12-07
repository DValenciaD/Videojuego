using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
//Delimita la posición del objeto con el tag "Player", para que el enemigo transforme su posición hasta el jugador 

public class Persecucion : MonoBehaviour
{
    public Transform playerPosition; 
    public float velocidadEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Perseguir(playerPosition, this.gameObject.tranform);
    }

    public void Perseguir(Transform player, Transform enemigo) //Seleciona a "player" como su objetivo y hace que el enemigo se dirija hacia el
    {
        Vector3 distancia = player.position - enemigo.position;

        enemigo.LookAt(distancia);
        enemigo.Translate(distancia.normalized * velocidadEnemigo * Time.deltaTime);
    }
}
