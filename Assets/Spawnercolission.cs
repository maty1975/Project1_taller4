using UnityEngine;

public class SpawnerCollision : MonoBehaviour
{
    public string targetTag;
    public GameObject objectToInstantiate; // El objeto que quieres instanciar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisi�n es con el objeto deseado
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Obtiene el punto de colisi�n
            ContactPoint2D contact = collision.contacts[0];
            Vector2 collisionPoint = contact.point;

            // Instancia el objeto en el punto de colisi�n
            Instantiate(objectToInstantiate, collisionPoint, Quaternion.identity);
        }
    }

    public void SpawnCollision()
    {
        // Este m�todo puede ser usado si deseas instanciar el objeto desde otro lugar
        // por ejemplo, desde un UnityEvent.
        if (objectToInstantiate != null)
        {
            // Suponiendo que quieres instanciar el objeto en la posici�n actual del SpawnerCollision
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("El objeto a instanciar no est� asignado.");
        }
    }
}
