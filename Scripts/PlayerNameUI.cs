using UnityEngine;
using TMPro;

public class PlayerNameUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (PlayerData.Instance != null)
        {
            nameText.text = PlayerData.Instance.GetPlayerName();
            scoreText.text = "Score: " + PlayerData.Instance.GetCurrentScore();

        }
        else
        {
            nameText.text = " --- ";
            scoreText.text = " --- ";


        }
    }

    void Update()
    {
        if (PlayerData.Instance != null)
        {
            scoreText.text = "Score: " + PlayerData.Instance.GetCurrentScore();
        }
    }

}