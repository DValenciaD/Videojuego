using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Agente
{
    // Daniela Itzel Valencia Durán
    // Programación Orientada a Objetos
    // Josue Israel Rivas Díaz
    // Ejecuta las animaciones del esqueleto y hace que siga al objeto 

    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    public float _velocidadAgente;

    Animator anim;
    EnemigoB enemigoB;

    // Start is called before the first frame update
    void Start()
    {
        VelocidadAgente = velocidad;
        enemigoB = FindObjectOfType<EnemigoB>();

        BusquedaEnemigo(Id);

        this.anim = GetComponent<Animator>();
        destino = GameObject.Find("Destino").GetComponent<Transform>();
        objetivo = GameObject.Find("Destino").GetComponent<Transform>();
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

    // Update is called once per frame
    void Update()
    {
        if (MedirDistanciaBool())
        {
            ConfigurarDestino(destino);

            if (MedirDistanciaFloat() <= freno)
            {
                Debug.Log("Toma");
                anim.SetBool("Atque", true);
            }
            else
            {
                anim.SetBool("Ataque", false);
            }
        }
        else if (!MedirDistanciaBool()) //Si "MedirDistanciaBool" es diferente
        {
            VelocidadAgente = 0;
        }
    }

}
