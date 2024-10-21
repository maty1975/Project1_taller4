using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class dificult : MonoBehaviour
{
    public int num;
    public int num_principal;
    public int num_obj;

    //public UnityEvent Primer 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumar_num()
    {
        num++;
    }

    public void verificar_obj()
    {
        if (num >= num_obj)
        {
            num_principal++;
            Resetear();
        }
    }

    public void Resetear()
    {
      num = 0;
    }
    public void ajustar_difuclta()
    {
        if (num_obj == 1)
        {

        }
        else if (num_obj == 2) 
        {

        }

    }
}
