using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Contador_manager : MonoBehaviour
{
    public int total;
    int num_guardado;
    public UnityEvent SE_ELIMINARON;
    // Start is called before the first frame update
    void Start()
    {
        num_guardado = total;
    }

    // Update is called once per frame
    void Update()
    {
        if (total <= 0)
        {
            SE_ELIMINARON.Invoke();
            resetear();
        }
    }

    public void Eliminar_bloque()
    {
        total--;
    }


    public void resetear()
    {
        total = num_guardado;
    }
}
