using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orden_Active : MonoBehaviour
{
    [Header("PARA SABER DONDE SE VA A SPAWNEAR")]
    //public GameObject Imagen_siguiente_TP;
    [Header("PARA EL TP DEL AGUADOR")]
    public UnityEvent CAMBIO_POSICION;
    public GameObject OBJETO_A_MOVER;
    public Transform[] Posicion;
    public float transitionDuration = 1.0f; // Duración de la transición en segundos
    public bool Se_ejecuta = true;

    private int previousIndex = -1;

    private void Start()
    {
        if (Se_ejecuta)
        {
            Cambia_posicion();
            //Imagen_siguiente_TP.transform.position = Posicion[GetRandomIndex()].position;
        }
    }

    [ContextMenu("TEST FUNCION")]
    public void Cambia_posicion()
    {
        StartCoroutine(TransitionToNextPosition());
    }

    private IEnumerator TransitionToNextPosition()
    {
        Vector3 startPosition = OBJETO_A_MOVER.transform.position;
        int randomIndex = GetRandomIndex();
        Vector3 endPosition = Posicion[randomIndex].position;

        float elapsedTime = 0f;

        // Move Imagen_siguiente_TP instantly to the next position
        //Imagen_siguiente_TP.transform.position = Posicion[GetRandomIndex()].position;

        // Smoothly transition AGUADOR to the next position
        while (elapsedTime < transitionDuration)
        {
            OBJETO_A_MOVER.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        OBJETO_A_MOVER.transform.position = endPosition;

        CAMBIO_POSICION.Invoke();
    }

    private int GetRandomIndex()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, Posicion.Length);
        } while (randomIndex == previousIndex); // Ensure the new position is different from the last one

        previousIndex = randomIndex;
        return randomIndex;
    }
}
