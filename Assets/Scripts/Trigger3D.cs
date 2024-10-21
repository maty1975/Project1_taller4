using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger3D : MonoBehaviour
{
    public string tag;
    public UnityEvent Trigger_enter;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tag))
        {
            Trigger_enter.Invoke();
            other.gameObject.SetActive(false);
        }
    }
}
