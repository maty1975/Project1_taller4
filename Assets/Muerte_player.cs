using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte_player : MonoBehaviour
{
    //public GameObject player;
    public GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void morir()
    {
        this.gameObject.SetActive(false);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
