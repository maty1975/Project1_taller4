using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Aleatorio : MonoBehaviour
{
    [Header("FORMAS QUE DISPARARA")]
    public GameObject[] FORMAS;
    [Header("SE DISPARARA ENTRE EL")]
    [Range (0f,10f)]
    public int primer_restante;
    [Range(0f, 10f)]
    public int segundo_restante;
    float Cooldown;
    [Header("DISPARO")]
    [Range(0f,10f)]
    public float fuerza;
    bool dispara;

    // Start is called before the first frame update
    void Start()
    {
        RNG_cooldown();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
        }
        else if (Cooldown <= 0)
        {
            dispara = (Random.value > 0.5f); // Random entre true o false

            if (dispara)
            {
                // Lógica para disparar
                int formaAleatoria = Random.Range(0, FORMAS.Length);
                GameObject objetoelegido = Instantiate(FORMAS[formaAleatoria], transform.position, Quaternion.identity);
                Rigidbody2D rb = objetoelegido.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * fuerza;//new Vector2(fuerza, 0);
                this.gameObject.SetActive(false);
            }

            RNG_cooldown(); // Reinicia el cooldown
        }
    }

    public void RNG_cooldown()
    {
        int seg_restante = Random.Range(primer_restante, segundo_restante);
        Cooldown = seg_restante;
    }

    public void Nueva_Fuerza(float fuerza_nueva)
    {
        fuerza = fuerza_nueva;
    }

    public void nuevo_cooldown(int nuevo_restante)
    {
        int seg_restante = Random.Range(1, nuevo_restante);
        Cooldown = seg_restante;
    }
}
