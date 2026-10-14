using UnityEngine;

public class VerticalDamageZone : MonoBehaviour
{
    public float amplitude = 2f;    // Hauteur max du mouvement vertical
    public float speed = 1f;        // Vitesse du mouvement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcul du décalage vertical en fonction du temps (oscillation sinusoïdale)
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}