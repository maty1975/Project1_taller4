using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Player_life : MonoBehaviour
{
    [Range(0f,1f)]
    public float HP;
    [Range(0f, 1f)]
    public float velocidad;
    public Image HP_UI;
    [SerializeField] bool tocando = true;
    public UnityEvent Al_PERDER_VIDA;
    public UnityEvent NADA;
    public UnityEvent AL_RELLENAR_VIDA;

    public UnityEvent BONUS;
    public UnityEvent NO_BONUS;
    public AudioSource life;


    float vida_actual;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        CAMBIO_DE_VIDA();
        mostrarvida();
        if (HP <= 0 )
        {
            Al_PERDER_VIDA.Invoke();
            HP = 0;
        }
        else if (HP >= 1)
        {
            AL_RELLENAR_VIDA.Invoke();
            HP = 1;
        }
        else
        {
            NADA.Invoke();
        }
        HP_UI.fillAmount = vida_actual;
        life.pitch = vida_actual;
        /*
        if (tocando && HP >= 1)
        {
            BONUS.Invoke();
        }
        else if (tocando)
        {
            NO_BONUS.Invoke();
        }
        */
    }
    public void mostrarvida()
    {
        vida_actual = HP / 1f;
    }



    public void CAMBIO_DE_VIDA()
    {
        if (tocando)
        {
            HP += velocidad * Time.deltaTime;
        }
        else
        {
            HP -= velocidad * Time.deltaTime;
        }
        
    }
    public void Curar()
    {
        tocando = true;
    }

    public void No_curar()
    {
        tocando = false;
    }

}
