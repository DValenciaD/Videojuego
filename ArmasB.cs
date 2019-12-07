using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Crea una lista de las armas con sus características

public class ArmasB : MonoBehaviour
{
    public List<Armas> armasPunzoCortantes;
    public List<Armas> armasDeFuego;

    void Awake()
    {
        armasPunzoCortantes.Add(new Armas("cuchillo", 10)); //Añade un arma a la lista
        armasDeFuego.Add(new Armas("magnum", 50, 6));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
