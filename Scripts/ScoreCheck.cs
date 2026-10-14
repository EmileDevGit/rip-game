using UnityEngine;
using TMPro; // si tu utilises TextMeshPro

public class ScoreZoneTrigger : MonoBehaviour
{
    public int scoreMinimum = 1500;
    public string messageSiScoreBas = "Tu dois avoir au moins 1500 de score pour continuer l'Aventure";

    public TextMeshProUGUI messageText; // Assigne-le dans l’inspecteur
    public float dureeAffichage = 2f;
    public Collider2D gotoEnd;

    private Coroutine hideCoroutine;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerData joueur = PlayerData.Instance;
                if (joueur.GetCurrentScore() < scoreMinimum)
                {
                    AfficherMessage(messageSiScoreBas);
                }
                else
                {
                    gotoEnd.isTrigger = true;
                }
            }
        }

    void AfficherMessage(string texte)
    {
        if (messageText != null)
        {
            messageText.text = texte;
            messageText.enabled = true;

            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            hideCoroutine = StartCoroutine(CacherApresDelai());
        }
    }

    System.Collections.IEnumerator CacherApresDelai()
    {
        yield return new WaitForSeconds(dureeAffichage);
        messageText.enabled = false;
    }
}