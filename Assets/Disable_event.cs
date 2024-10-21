using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Disable_event : MonoBehaviour
{
    public UnityEvent AL_DESACTIVAR_GAMEOBJECT;
    private void OnDisable()
    {
        AL_DESACTIVAR_GAMEOBJECT.Invoke();
    }
}
