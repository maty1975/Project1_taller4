using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShakeController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cámara virtual de Cinemachine
    public float shakeDuration = 1f; // Duración del temblor en segundos
    public float shakeAmplitude = 2f; // Amplitud (intensidad) del temblor
    public float shakeFrequency = 2f; // Frecuencia del temblor

    private CinemachineBasicMultiChannelPerlin perlin; // Componente para la sacudida
    private float initialAmplitude; // Amplitud inicial para restaurar
    private float initialFrequency; // Frecuencia inicial para restaurar

    private void Start()
    {
        // Asegurarse de que la cámara virtual tenga el componente de Perlin Noise
        if (virtualCamera != null)
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (perlin != null)
            {
                // Guardar los valores iniciales para restaurar más tarde
                initialAmplitude = perlin.m_AmplitudeGain;
                initialFrequency = perlin.m_FrequencyGain;
            }
            else
            {
                Debug.LogError("No se encontró el componente CinemachineBasicMultiChannelPerlin en la cámara virtual.");
            }
        }
        else
        {
            Debug.LogError("No se ha asignado ninguna cámara virtual.");
        }
    }

    // Función para iniciar el temblor de la cámara
    [ContextMenu("Shake Camera")]
    public void ShakeCamera()
    {
        if (perlin != null)
        {
            // Comenzar el temblor
            perlin.m_AmplitudeGain = shakeAmplitude;
            perlin.m_FrequencyGain = shakeFrequency;

            // Iniciar la corrutina que detendrá el temblor después de shakeDuration
            StartCoroutine(StopShakingAfterDuration());
        }
    }

    // Corrutina para detener el temblor después de un tiempo
    private IEnumerator StopShakingAfterDuration()
    {
        // Espera por el tiempo definido en shakeDuration
        yield return new WaitForSeconds(shakeDuration);

        // Restaurar la amplitud y frecuencia iniciales
        if (perlin != null)
        {
            perlin.m_AmplitudeGain = initialAmplitude;
            perlin.m_FrequencyGain = initialFrequency;
        }
    }
}
