using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mostrar_conteo : MonoBehaviour
{
    public TextMeshProUGUI TEXT;
    // Start is called before the first frame update
    

    public void mostrar_texto(string mensaje)
    {
        TEXT.text = mensaje;
    }
}
