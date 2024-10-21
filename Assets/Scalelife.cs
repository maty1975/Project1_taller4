using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scalelife : MonoBehaviour
{
    [Range (-1f,1f)]
    public float velocidad_reduccion;
    [Range(0f, 2f)]
    public float maximo_tama�o;
    Vector3 tamano;
    Vector3 tamano_muerte;
    Vector3 tama�o_max;
    public UnityEvent SE_MURIO;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cambiar_tamano();
        asignar_tama�o_maximo();
        if (transform.localScale.x <= 0.1f && transform.localScale.y <= 0.1f && transform.localScale.z <= 0.1f)
        {
            //Destroy(gameObject);
            SE_MURIO.Invoke();
        }
        else if (transform.localScale.x >= maximo_tama�o && transform.localScale.y >= maximo_tama�o && transform.localScale.z >= maximo_tama�o)
        {
            transform.localScale = Vector3.Scale(tama�o_max, tama�o_max);
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
    public void nuevo_tama�o(float tama�o_nuevo)
    {
        velocidad_reduccion = tama�o_nuevo;
    }

    public void asignar_tama�o_maximo()
    {
        tama�o_max = new Vector3(maximo_tama�o, maximo_tama�o, maximo_tama�o);
    }
}
