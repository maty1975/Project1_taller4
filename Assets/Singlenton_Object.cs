using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlenton_Object : MonoBehaviour
{
    private void Awake()
    {
        // Verifica si ya existe una instancia del objeto
        if (FindObjectsOfType<Singlenton_Object>().Length > 1)
        {
            // Si ya existe otra instancia, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }
        else
        {
            // No destruir al cambiar de escena
            DontDestroyOnLoad(gameObject);
        }
    }
}
