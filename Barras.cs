using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Crea las barras de vida del enemigo 

public class Barras : MonoBehaviour
{
    public Slider[] barras;
    public int vida;
    CEnemigo vidaEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = GetComponentInParent<CEnemigo>(); //"vidaEnemigo" obtine componente de "CEnemigo"

        StartCoroutine("asignarvida"); //Ejecuta la corrutina "asignarvida"
    }

    // Update is called once per frame
    void Update()
    {
        barras[0].value = vidaEnemigo.vida;
        if (vidaEnemigo.vida == 0) //
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    IEnumerator asignarvida() //Una corrutina es una función que tiene la habilidad de pausar su ejecución y devolver el control a Unity para luego continuar donde lo dejó en el siguiente frame
    {
        yield return new WaitForSeconds(1); //Introduce un tiempo de retardo
        if (vidaEnemigo != null)
        {
            vida = vidaEnemigo.vida;
            barras[0].maxValue = vida;
            barras[0].value = barras[0].maxValue;
        }
    }

    //Cuando una tarea no necesita ser repetida tan frecuentemente, puedes ponerla en una corrutina para obtener una actualización regularmente pero no en cada frame

    IEnumerator asignarBarra()
    {
        yield return new WaitForSeconds(1); //Es el punto en el cual la ejecución se pausará y reanudará en el siguiente frame
        barras = new Slider[2];
        barras = GetComponentsInChildren<Slider>();
        vida = vidaEnemigo.vida;
        for (int i = 0; i < barras.Length; i++) 
        {
            barras[i] = barras[i];

            if (i == 0 )
            {
                barras[i].maxValue = vida;
                barras[i].value = barras[i].maxValue;
            }
        }
    }
}
