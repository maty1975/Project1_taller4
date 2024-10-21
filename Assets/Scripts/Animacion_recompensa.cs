using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion_recompensa : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activar_parametro(string condicion)
    {
        animator.SetBool(condicion, true);
    }

    public void desactivar_parametro(string condicion)
    {
        animator.SetBool(condicion, false);
    }
}
