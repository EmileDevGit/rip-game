using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button confirmNameButton;
    public Button[] menuButtons;

    public AudioSource btnClickAudio;

    void Start()
    {
        // Charger le nom du joueur sauvegardé
        string savedName = PlayerData.Instance.GetPlayerName();

        if (!string.IsNullOrWhiteSpace(savedName))
        {
            nameInputField.text = savedName;
            SetMenuButtonsInteractable(true); // Activer les boutons si nom déjà valide
        }
        else
        {
            SetMenuButtonsInteractable(false);
        }

    }

    public void OnConfirmName()
    {
        string enteredName = nameInputField.text;

        bool isValid = !string.IsNullOrWhiteSpace(enteredName);
        if (isValid)
        {
            PlayerData.Instance.SetPlayerName(enteredName);
            SetMenuButtonsInteractable(true);
        }
    }

    public void OnClickReset()
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.ResetPlayerData();
        }
    }

    void SetMenuButtonsInteractable(bool state)
    {
        foreach (Button btn in menuButtons)
        {
            btn.interactable = state;
        }
    }

    public void PlaySoundButtonClick()
    {
        btnClickAudio.Play();
    }
}
