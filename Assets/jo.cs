using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class jo : MonoBehaviour
{
    public string tag;
    public UnityEvent AL_tOCAR;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            AL_tOCAR.Invoke();
        }
    }
}
