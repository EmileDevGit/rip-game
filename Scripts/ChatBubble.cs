using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] private Transform backgroundQuad; // Fond du message
    [SerializeField] private TextMeshPro textMesh; // Texte affiché

    private void Awake()
    {
        // Récupération des éléments dans les enfants de l'objet
        backgroundQuad = transform.Find("Background");
        textMesh = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    // Configure le texte du message
    public void Setup(string message)
    {
        textMesh.text = message;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.enableWordWrapping = true;

        textMesh.ForceMeshUpdate(); // Met à jour les dimensions du texte

        // Récupère la taille du texte
        var bounds = textMesh.textBounds;
        Vector3 boundsSize = bounds.size;

        // Marges autour du texte
        float paddingX = 0.2f;
        float paddingY = 0.1f;

        // Adapter la taille du fond au texte
        backgroundQuad.localScale = new Vector3(boundsSize.x + paddingX, boundsSize.y + paddingY, 1f);

        // Centrer les éléments
        backgroundQuad.localPosition = Vector3.zero;
        textMesh.transform.localPosition = new Vector3(3.3f, 0f, -0.01f); // Léger décalage pour éviter un chevauchement (z-fighting)
    }

    // Crée une bulle de texte, l’affiche et la détruit après 8 secondes
    public static ChatBubble Create(GameObject prefab, Transform parent, Vector3 localPosition, string message)
    {
        GameObject chatBubbleObject = Object.Instantiate(prefab, parent);
        chatBubbleObject.transform.localPosition = localPosition;

        ChatBubble chatBubble = chatBubbleObject.GetComponent<ChatBubble>();
        chatBubble.Setup(message);

        Object.Destroy(chatBubbleObject, 8f); // Auto-destruction
        return chatBubble;
    }

    private void LateUpdate()
    {
        if (Camera.main != null)
        {
            // Tourner la bulle vers la caméra principale
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}
