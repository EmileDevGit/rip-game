using UnityEngine;

public class QuestRequirementChatBubble : MonoBehaviour
{
    public JoueurInventaire joueurInventaire;      // Reference to inventory
    public GameObject chatBubblePrefab;            // Prefab for the chat bubble
    public Transform chatBubbleAnchor;             // Where the bubble appears
    public string interactText = "";

    [TextArea]
    public string hasKeyText = "You have a key! You can proceed.";
    
    [TextArea]
    public string noKeyText = "The door is locked. You need a key.";

    public void ShowKeyMessage()
    {
        if (chatBubblePrefab == null || chatBubbleAnchor == null)
        {
            Debug.LogWarning("ChatBubble prefab or anchor not assigned!");
            return;
        }

        string message = (joueurInventaire != null && joueurInventaire.NumberOfKeys >= 1) ? hasKeyText : noKeyText;
        ChatBubble.Create(chatBubblePrefab, chatBubbleAnchor, Vector3.zero, message);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
