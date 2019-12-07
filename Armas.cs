using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Genera los datos de las armas

public class Armas : MonoBehaviour
{
    public string nombre;
    public int daño;
    public int municion;
    public int ExtraPorExplosion;

    public Armas(string n, int d) //Se generan constructores que permiten establecer valores predeterminados, limitar la creación de instancias y escribir código flexible y fácil de leer
    {
        this.nombre = n;
        this.daño = d;
    }

    public Armas(string n, int daño, int m)
    {
        this.nombre = n;
        this.daño = daño;
        this.municion = m;
    }
}
