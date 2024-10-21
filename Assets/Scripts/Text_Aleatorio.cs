using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Aleatorio : MonoBehaviour
{
    // Referencia al TextMesh en la escena
    public TextMesh textMesh;

    // Lista de textos para elegir aleatoriamente
    public string[] textOptions;

    // Método para establecer un texto aleatorio
    public void DisplayRandomText()
    {
        if (textOptions.Length > 0)
        {
            // Seleccionar un texto aleatorio de la lista
            int randomIndex = Random.Range(0, textOptions.Length);
            string randomText = textOptions[randomIndex];

            // Asignar el texto al TextMesh
            textMesh.text = randomText;
        }
        else
        {
            Debug.LogWarning("La lista de textos está vacía.");
        }
    }

    // Método opcional para llamar DisplayRandomText al inicio
    void Start()
    {
        DisplayRandomText();
    }
}
