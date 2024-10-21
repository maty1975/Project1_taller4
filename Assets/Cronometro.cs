using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI Timertext;
    public float elapsedtime;

    public UnityEvent PASO_1_MINUTO;
    void Update()
    {
        elapsedtime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedtime / 60);
        int seconds = Mathf.FloorToInt(elapsedtime % 60);

        Timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void mostrar_tiempo_aguantado(TextMeshProUGUI otro_texto2)
    {
        otro_texto2.text = Timertext.text;
    }
}
