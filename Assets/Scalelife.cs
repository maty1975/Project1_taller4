using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scalelife : MonoBehaviour
{
    [Range (-1f,1f)]
    public float velocidad_reduccion;
    [Range(0f, 2f)]
    public float maximo_tamaño;
    Vector3 tamano;
    Vector3 tamano_muerte;
    Vector3 tamaño_max;
    public UnityEvent SE_MURIO;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cambiar_tamano();
        asignar_tamaño_maximo();
        if (transform.localScale.x <= 0.1f && transform.localScale.y <= 0.1f && transform.localScale.z <= 0.1f)
        {
            //Destroy(gameObject);
            SE_MURIO.Invoke();
        }
        else if (transform.localScale.x >= maximo_tamaño && transform.localScale.y >= maximo_tamaño && transform.localScale.z >= maximo_tamaño)
        {
            transform.localScale = Vector3.Scale(tamaño_max, tamaño_max);
        }
    }
    public void cambiar_tamano()
    {
        tamano = new Vector3(velocidad_reduccion, velocidad_reduccion, velocidad_reduccion) * Time.deltaTime;
        transform.localScale -= tamano;
        
        if (transform.localScale.x < 0f || transform.localScale.y < 0f || transform.localScale.z < 0f)
        {
            transform.localScale = Vector3.zero;
        }
    }
    public void nuevo_tamaño(float tamaño_nuevo)
    {
        velocidad_reduccion = tamaño_nuevo;
    }

    public void asignar_tamaño_maximo()
    {
        tamaño_max = new Vector3(maximo_tamaño, maximo_tamaño, maximo_tamaño);
    }
}
