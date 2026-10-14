using UnityEngine;
using TMPro;
using System;

public class NameInputUI : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void OnSubmitName()
    {
        string enteredName = nameInputField.text;

        if (!string.IsNullOrEmpty(enteredName))
        {
            PlayerData.Instance.SetPlayerName(enteredName);
        }
    }
}

