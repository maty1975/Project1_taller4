using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SpawnerSimple : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject spawnObject;
    public UnityEvent AL_SPAWNEAR;

    public void Spawnear()
    {
        Instantiate(spawnObject, spawnPosition.position, spawnPosition.rotation);
        AL_SPAWNEAR.Invoke();


    }
}
