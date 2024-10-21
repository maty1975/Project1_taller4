using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class timer : MonoBehaviour
{
    //PUBLICO
    public float Tiempo;
    public UnityEvent TERMINO_TIEMPO;
    public bool COMENZAR_TIEMPO = true;
    //PRIVADO
    float time;
    // Start is called before the first frame update
    void Start()
    {
         time = Tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (COMENZAR_TIEMPO) 
        {
            comenzar();

            if (Tiempo <= 0) 
            {
                TERMINO_TIEMPO.Invoke();
                resetear();
                COMENZAR_TIEMPO=false;
            }
        }
    }
    public void comenzar()
    {
        Tiempo -= Time.deltaTime;
    }

    public void resetear()
    {
        Tiempo = time;
    }

    public void time_on()
    {
        COMENZAR_TIEMPO = true;
    }
    public void time_off()
    {
        COMENZAR_TIEMPO = false;
    }
}
