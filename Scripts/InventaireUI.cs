using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class InventaireUI : MonoBehaviour
{

    private TextMeshProUGUI keyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    public void UpdateKeyText(JoueurInventaire joueurInventaire)
    {
        keyText.text = joueurInventaire.NumberOfKeys.ToString();
    }

}
