using UnityEngine;
using UnityEngine.UI;

public class TouchObjectController : MonoBehaviour
{
    public Image targetObject; // Referencia al objeto de UI (debe tener un componente Image)
    public float touchOpacity = 0.5f; // Opacidad cuando se toca la pantalla
    public float defaultOpacity = 1.0f; // Opacidad cuando no se toca la pantalla

    private Color targetColor;

    void Start()
    {
        if (targetObject != null)
        {
            targetColor = targetObject.color;
            SetOpacity(defaultOpacity);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; // Establece Z a 0 para asegurar que el objeto esté en el plano de la cámara

                // Coloca el objeto en la posición del toque
                targetObject.transform.position = touchPosition;

                // Cambia la opacidad del objeto al tocar
                SetOpacity(touchOpacity);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Cambia la opacidad del objeto al soltar el toque
                SetOpacity(defaultOpacity);
            }
        }
    }

    void SetOpacity(float opacity)
    {
        if (targetObject != null)
        {
            targetColor.a = opacity;
            targetObject.color = targetColor;
        }
    }
}
