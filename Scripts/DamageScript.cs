using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 20;
    public float rotationSpeed = 100f; // Vitesse en degrés par seconde

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet touché a le script "Player"
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.PlayerTakeDamage(damageAmount);
        }
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}