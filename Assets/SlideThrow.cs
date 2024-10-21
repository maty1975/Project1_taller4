using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class SlideThrow : MonoBehaviour
{
    public int municion;
    public LayerMask layerMask;
    public GameObject objetoPrefab, objetoEscena;
    public float fuerza;
    public float gravityScale;
    public UnityEvent AL_ACABARSE;
    public UnityEvent AL_LANZAR_PELOTA;
    public TextMeshProUGUI text_muniicion;
    Touch touch;
    
    int largoHistorial = 10;

    Vector3 startPosBall;

    Vector3 prevPos, currentPos;
    Vector3 posicionPelota;
    Quaternion rotacionPelota;

    HistorialPosiciones[] posiciones;

    private void Start()
    {
        actualizar_cant_municion();
        startPosBall = objetoEscena.transform.position;
        Physics.gravity = new Vector3(0, Physics.gravity.y * gravityScale, 0);
        posiciones = new HistorialPosiciones[largoHistorial];
    }

    public struct HistorialPosiciones
    {
        public Vector3 posicion;
        public float tiempo;

        public HistorialPosiciones(Vector3 _pos , float _t)
        {
            posicion = _pos;
            tiempo = _t;
        }

    }

    void ActualizarHistorial(Vector3 _lastPos, float _lastTime)
    {
        for (int i = posiciones.Length - 1; i > 0 ; i--)
        {
            posiciones[i].posicion = posiciones[i - 1].posicion;
            posiciones[i].tiempo = posiciones[i - 1].tiempo;
        }

        posiciones[0].posicion = _lastPos;
        posiciones[0].tiempo = _lastTime;
    }

    


    private void Update()
    {


        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                prevPos = PosicionEnPlano(touch.position);
                ResetearPosiciones(PosicionEnPlano(touch.position), Time.time);
                posicionPelota = PosicionEnPlano(touch.position);
            }

            if(touch.phase == TouchPhase.Moved)
            {
                ActualizarHistorial(objetoEscena.transform.position, Time.time);

                prevPos = posiciones[largoHistorial - 1].posicion;
                currentPos = posiciones[0].posicion;

                Vector3 direccion = (currentPos - prevPos).normalized;

                posicionPelota = PosicionEnPlano(touch.position);
                rotacionPelota = DireccionObjeto(direccion);


            }

            if (touch.phase == TouchPhase.Ended)
            {

                ActualizarHistorial(objetoEscena.transform.position, Time.time);

                prevPos = posiciones[largoHistorial - 1].posicion;
                currentPos = posiciones[0].posicion;

                Vector3 direccion = (currentPos - prevPos).normalized;
                float magnitud = (currentPos - prevPos).magnitude;
           
                LanzarPelota(magnitud);
                AL_LANZAR_PELOTA.Invoke();

            }

            objetoEscena.transform.position = posicionPelota;
            objetoEscena.transform.rotation = rotacionPelota;

        }
        else
        {
            objetoEscena.transform.position = startPosBall;
            objetoEscena.transform.localEulerAngles = Vector3.zero;
        }



    }



    Vector3 PosicionEnPlano(Vector2 _touchPos)
    {
        Vector3 p = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(_touchPos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
        {
            p = hitInfo.point;
        }

        return p;
    }


    Quaternion DireccionObjeto(Vector3 _direccion)
    {
        _direccion.z = Mathf.Abs(_direccion.y);
        return Quaternion.LookRotation(_direccion);       
    }

    public void verificar_municion()
    {
        if (municion == 1)
        {
            AL_ACABARSE.Invoke();
        }
    }

    public void actualizar_cant_municion()
    {
        text_muniicion.text = "x"+municion.ToString();
    }

    void LanzarPelota(float _fuerza)
    {
        GameObject _ball = Instantiate(objetoPrefab);
        Rigidbody _rb = _ball.GetComponent<Rigidbody>();
        
        _ball.transform.position = objetoEscena.transform.position;
        _ball.transform.rotation = objetoEscena.transform.rotation;
       
        _rb.isKinematic = false;
        _rb.AddForce(_ball.transform.forward * _fuerza * fuerza, ForceMode.Impulse);

        //municion--;

        objetoEscena.transform.localScale = Vector3.zero;
        
        print(startPosBall);

        RecargarPelota();
    }

    void RecargarPelota()
    {
        if (municion < 1) return;

        StartCoroutine(AnimacionRecarga());
    }

    public void quitar_municion()
    {
        municion--;
    }

    public void aumentar_municion(int cant)
    {
        municion+= cant;
    }

    void ResetearPosiciones(Vector3 _pos, float _t)
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            posiciones[i].posicion = _pos;
            posiciones[i].tiempo = _t;
        }
    }


    IEnumerator AnimacionRecarga()
    {
        float t = 0;
        float lerpTime = 0.5f;
        float waitTime = 0.1f;

        yield return new WaitForSeconds(waitTime);


        while (t < lerpTime)
        {
            t += Time.deltaTime;
            float p = t / lerpTime;
            p = Mathf.Sin(p * Mathf.PI * 0.5f);

            objetoEscena.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2,2,2), p);
            yield return null;
        }

        objetoEscena.transform.localScale = new Vector3(2, 2, 2);




    }

}
