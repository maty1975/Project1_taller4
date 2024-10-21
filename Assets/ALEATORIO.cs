using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ALEATORIO : MonoBehaviour
{

    //PUBLICO
    public GameObject[] PATRONES;
    public List<int> num_usados = new List<int>(); // Inicializar la lista correctamente
    public UnityEvent SIGUIENTE_NIVEL;
    //PRIVADO
    int numero_anterior;
    int total_de_patrones;
    int elegido;

    void Start()
    {
        total_de_patrones = PATRONES.Length;
    }

    public void ELEGIR_PATRON()
    {
        // Generar un número aleatorio asegurándote de que no se repita
        elegido = lanzar_RNG();

        // Activar el patrón correspondiente
        ACTIVAR_PATRON();

        // Guardar el número usado
        agregar();
    }

    public int lanzar_RNG()
    {
        int num_aleatorio;

        // Loop para encontrar un número que no haya sido usado
        do
        {
            num_aleatorio = Random.Range(0, total_de_patrones);
        } while (num_usados.Contains(num_aleatorio));

        return num_aleatorio;
    }

    public void ACTIVAR_PATRON()
    {
        PATRONES[elegido].SetActive(true);
    }

    [ContextMenu("AGREGAR A LA LISTA")]
    public void agregar()
    {
        num_usados.Add(elegido);

        // Opcional: Si ya has usado todos los números posibles, puedes vaciar la lista
        if (num_usados.Count >= total_de_patrones)
        {
            num_usados.Clear();
            SIGUIENTE_NIVEL.Invoke();
            Debug.Log("Todos los patrones se han usado. Reiniciando la lista.");
        }
    }
}
