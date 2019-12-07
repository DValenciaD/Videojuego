using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Crea las características del enemigo

[System.Serializable]
public class Enemigo : MonoBehaviour
{
    public string nombre;
    public int vida;
    public int magia;

    public Enemigo(int v, int m, string n) //Recibe los parámetros
    {
        this.vida = v;
        this.magia = m;
        this.nombre = n;
    }
}
