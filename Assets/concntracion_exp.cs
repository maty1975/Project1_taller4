using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class concntracion_exp : MonoBehaviour
{
    [Range(1f,5f)]
    public float tiempo_segunda_exp;
    public GameObject concentracionParticulas;
    public GameObject explosionParticulas;
    
    void Start()
    {
        StartCoroutine(ExplodeAfterTime(tiempo_segunda_exp)); // Ajusta el tiempo según lo necesites
    }

    IEnumerator ExplodeAfterTime(float time)
    {
        Instantiate(concentracionParticulas, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        Instantiate(explosionParticulas, transform.position, Quaternion.identity);
    }
}
