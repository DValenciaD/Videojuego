using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Hace que el conejo ejecute sus animaciones y se dirija al un punto específico

public class CEnemigo : Agente
{ 
    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    EnemigoB enemigoB;
    Animator animConejo;
    
    // Start is called before the first frame update
    void Start()
    {
        enemigoB = FindObjectOfType<EnemigoB>(); //"enemigoB" busca un tipo de objeto "EnemigoB" 
        BusquedaEnemigo(Id);
        animConejo = GetComponent<Animator>(); //Retorna un componente de tipo Animator 

    }

    private void BusquedaEnemigo(string id)
    {
        for (int i = 0; i < enemigoB.enemigo.Count; i++)
        {
            if (id == enemigoB.enemigo[i].nombre)
            {
                nombre = enemigoB.enemigo[i].nombre;
                vida = enemigoB.enemigo[i].vida;
                magia = enemigoB.enemigo[i].magia;
            }
        }
    }

    private void Update()
    {
        ConfigurarDestino(destino); //Punto que el agente toma como referencia para llegar
    }
}
