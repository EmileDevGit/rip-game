using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private JoueurInteract joueurInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;


    private void Update(){
        var interactable = joueurInteract.getInteractableObject();

    if (interactable != null)
    {
        if (interactable.TryGetComponent<NPCInteractable>(out var npc))
        {
            Show(npc.GetInteractText());
        }
        else if (interactable.TryGetComponent<TurnScript>(out var door))
        {
            Show(door.GetInteractText());
        }
        else if (interactable.TryGetComponent<QuestRequirementChatBubble>(out var chatTrigger))
        {
            Show(chatTrigger.GetInteractText());
        }
        
    }
    else
    {
        Hide();
    }
    }
    
   private void Show(string text)
{
    containerGameObject.SetActive(true);
    interactTextMeshProUGUI.text = text;
}

    private void Hide(){
        containerGameObject.SetActive(false);
    }
}
