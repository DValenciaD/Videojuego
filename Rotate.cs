using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Rota al objeto

public class Rotate : MonoBehaviour
{
    float rotate;

    // Update is called once per frame
    void Update()
    {
        rotate += Input.GetAxis("Horizontal2") * 2; //Devuelve el valor del eje "Horizotal2"
        //rotate = Mathf.Clamp(rotate, -60, 60);

        transform.rotation = Quaternion.Euler(0, rotate, 0); //Devuelve una rotación que gira o grados en z, x equivale al valor de "rotate" y 0 grados alrededor de y

        //if (rotate <= -60 || rotate >= 60)
        //{
        //    transform.rotation = Quaternion.LookRotation(Vector3.forward.normalized * Time.deltaTime);
        //}

        //transform.Rotate(0, rotate * 1f, 0);
    }
}
