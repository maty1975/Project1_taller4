using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnable_event : MonoBehaviour
{
    public UnityEvent AL_ACTIVAR_GAMEOBJECT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        AL_ACTIVAR_GAMEOBJECT.Invoke();
    }
}
