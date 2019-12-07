using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniela Itzel Valencia Durán
// Programación Orientada a Objetos
// Josue Israel Rivas Díaz
// Hace que el objeto vea un objetivo y lo siga hasta que tenga cierta distancia 

public class Agente : MonoBehaviour
{
    [SerializeField] // Permite ver el codifgo en la interface, pero se encuetra protegido
    protected float velocidad;
    [SerializeField]
    protected Transform destino;
    [SerializeField]
    protected float freno;


    protected void ConfigurarDestino(Transform d)
    {

        Vector3 destinoFinal = new Vector3(d.position.x, this.transform.position.y, d.position.z); //Define en una area de terreno el punto de destino al que se va a llegar 
        ConfiguracionFreno(destinoFinal, freno); 

        transform.LookAt(destinoFinal); // hace que el personaje voltee a la posicion del destino
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime); //Hace que se traslade hacie el punto de destino
        

        
    }

    protected bool ConfiguracionFreno(Vector3 d, float f) // "bool" obliga al metodo a regresar un dato de tipo bool; "f" indica el valor de freno
    {
        float velocidadLocal = 1; // Regresa la velocidad de información al valor original ()
        float distancia = Vector3.Distance(transform.position, d); //Regresa distancia que hay entre destino final d.poistion y el objeto dueño del código
        
        // Mide la distanca entre los dos objetos

        if (distancia < f) // Si el freno es menor que la distancia
        {
            velocidad = 0;// Devuelve el valor de velocidad asigando a 0 porque disminuye la velocidad con la que se traslada 
            return (true); // Comprueba el objeto booleano
        }
        else
        {
            velocidad = velocidadLocal; // Retorna a la velocidad local
            return (false);
        }
    }

    protected bool MedirDistancia()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = Vector3.Distance(transform.position, metaPos);
        Debug.Log(distancia);
        return distancia;
    }

    protected bool MedirDistanciaBool()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = new Vector3.Distancia(tranform.position, metaPos);

        if (distancia < distanciaMeta) //Hace comparación entre distancia y distancia meta
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
