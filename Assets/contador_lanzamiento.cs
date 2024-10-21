using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class contador_lanzamiento : MonoBehaviour
{
    public int lanzamientos;
    public TextMeshProUGUI text_lanzamientos;

    public void sumar_lanzamiento()
    {
        lanzamientos++;
    }

    public void actualizar_text_lanzamiento()
    {
        text_lanzamientos.text = lanzamientos.ToString();
    }

    public void mostrar_cantidad_de_lanzamiento(TextMeshProUGUI textoamostrar)
    {
        textoamostrar.text = lanzamientos.ToString();
    }
}
