using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private GameObject chatBubblePrefab; // Assign in Inspector
    [SerializeField] private Transform chatBubbleAnchor;
    [SerializeField] private string interactText;

    [SerializeField] private string baseCharacterText = "";

    [SerializeField] private bool useKeyCheck = false;
    [SerializeField] private string noKeyText = "";
    [SerializeField] private string hasKeyText = "";

    [SerializeField] private JoueurInventaire joueurInventaire;
    private NPC npcScript;

    void Awake()
    {
        npcScript = GetComponent<NPC>();
    }

    public void Interact()
    {
        string messageToShow = baseCharacterText;

        if (useKeyCheck && joueurInventaire != null)
        {
            if (joueurInventaire.NumberOfKeys >= 1)
            {
                messageToShow = hasKeyText;
            }
            else
            {
                messageToShow = noKeyText;
            }

            npcScript?.TriggerInteraction();

        }

        if (chatBubblePrefab != null)
        {
            Transform anchor = chatBubbleAnchor != null ? chatBubbleAnchor : transform;
            Vector3 offset = chatBubbleAnchor != null ? Vector3.zero : new Vector3(0f, 2.2f, 0f);

            ChatBubble.Create(chatBubblePrefab, anchor, offset, messageToShow);
        }
        else
        {
            Debug.LogWarning("ChatBubble prefab is not assigned on " + gameObject.name);
        }

    }

    public string GetInteractText()
    {
        return interactText;
    }
}
