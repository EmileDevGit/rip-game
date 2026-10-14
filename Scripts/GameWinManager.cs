using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryUI; // Interface de victoire à afficher (UI Canvas)

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (victoryUI != null)
            {
                victoryUI.SetActive(true); // Affiche une UI de victoire
                
                Time.timeScale = 0f; // Met en pause si nécessaire
            }
        }
    }
}