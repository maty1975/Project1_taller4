using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PUNTAJE : MonoBehaviour
{
    public TextMeshProUGUI text_score;

    public int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrar_puntaje()
    {
        text_score.text = score.ToString();
    }

    public void agregar_puntaje()
    {
        score += 1;
        mostrar_puntaje();
    }

    public void mostrar_puntaje_otro_texto(TextMeshProUGUI otro_texto)
    {
        otro_texto.text = score.ToString();
    }
}
