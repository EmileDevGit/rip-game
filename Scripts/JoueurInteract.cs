using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class JoueurInteract : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() {
    if (Input.GetKeyDown(KeyCode.E)) {
        GameObject interactable = getInteractableObject();
        if (interactable != null) {
            if (interactable.TryGetComponent<NPCInteractable>(out var npc)) {
                npc.Interact();
            }
            else if (interactable.TryGetComponent<TurnScript>(out var door)) {
                door.OpenDoor();
            } else if (interactable.TryGetComponent<QuestRequirementChatBubble>(out var chatTrigger)){
                chatTrigger.ShowKeyMessage();
            }

        }
    }
}


    public GameObject getInteractableObject() {
    GameObject closestInteractable = null;
    float closestDistance = float.MaxValue;
    float interactRange = 2f;

    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    foreach (Collider collider in colliderArray) {
        GameObject obj = collider.gameObject;

        if (obj.TryGetComponent<NPCInteractable>(out _) || obj.TryGetComponent<TurnScript>(out _)) {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestInteractable = obj;
            }
        }
    }

    return closestInteractable;
}

    
}
