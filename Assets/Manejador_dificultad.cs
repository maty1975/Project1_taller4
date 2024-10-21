using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manejador_dificultad : MonoBehaviour
{
    public int ID_dificultad;
    public bool se_ejecuta = true;
    public SystemSCORE systemscore;

    private int siguiente_umbral = 100; // El próximo umbral de puntos para aumentar dificultad

    public UnityEvent SEGUNDO_NIVEL;
    public UnityEvent TERCER_NIVEL;
    public UnityEvent CUARTO_NIVEL;

    public void aumentar_dificultad(int acumulador)
    {
        ID_dificultad += acumulador;
    }

    public void verificar_puntaje()
    {
        if (systemscore != null && se_ejecuta)
        {
            if (systemscore.score >= siguiente_umbral)
            {
                aumentar_dificultad(1);
                asignar_dificultad();
                se_ejecuta = false; // Desactivamos para no ejecutar de nuevo

                // Establecemos el próximo umbral a alcanzar
                siguiente_umbral += 100;
                //aumentar_dificultad(1);
            }
        }
    }

    public void asignar_dificultad()
    {
        if (ID_dificultad == 1)
        {
            SEGUNDO_NIVEL.Invoke();
        }
        else if (ID_dificultad == 2)
        {
            TERCER_NIVEL.Invoke();
        }
        else if (ID_dificultad == 3)
        {
            CUARTO_NIVEL.Invoke();
        }
    }

    public void activar_booleano_de_nivel()
    {
        se_ejecuta = true;
    }

    private void Update()
    {
        // Verifica continuamente si se puede activar el booleano
        if (!se_ejecuta && systemscore.score >= siguiente_umbral)
        {
            activar_booleano_de_nivel();
        }

        verificar_puntaje();
    }
}
