using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_physic_m : MonoBehaviour
{
    public PhysicsMaterial2D physicsMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiar_rebote(int V_rebote)
    {
        physicsMaterial.bounciness = V_rebote;
    }
}
