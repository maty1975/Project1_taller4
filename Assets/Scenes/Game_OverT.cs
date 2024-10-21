using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_OverT : MonoBehaviour
{
    public UnityEvent al_activar_gameover;
    private void OnEnable()
    {
        al_activar_gameover.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
