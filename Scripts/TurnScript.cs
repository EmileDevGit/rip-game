using UnityEngine;

public class TurnScript : MonoBehaviour
{
    public Transform pivotPoint;              // Hinge position
    public float rotationSpeed = 30f;         // Degrees per second
    public float rotationDuration = 3f;       // Rotation time
    public JoueurInventaire joueurInventaire; // Reference to inventory

    private float rotationTimer = 0f;
    private bool isRotating = false;
    private bool isUnlocked = false;

    public GameObject chatBubblePrefab; // Assign your ChatBubble prefab here
    public Transform chatBubbleAnchor;  // Assign a transform near the door (like above the handle or center)

    [SerializeField] private string noKeyText = "The door is locked. You need a key.";

    [SerializeField] private string interactText;

    [SerializeField] private Vector3[] direction = new Vector3[] {Vector3.up, Vector3.down, Vector3.right, Vector3.left};

    [SerializeField] private int directionChoice = 0;

     [Header("Audio Clips")]
    public AudioClip doorOpenSound;
    public AudioClip doorLockedSound;
    private AudioSource audioSource;

    



    public string GetInteractText()
{
    return interactText;
}
 void Awake()
    {
        // Get AudioSource from the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on TurnScript GameObject.");
        }
    }


    void Update()
    {
        if (isRotating)
        {
            float delta = Time.deltaTime;
            rotationTimer -= delta;

            transform.RotateAround(pivotPoint.position, direction[directionChoice], rotationSpeed * delta);

            if (rotationTimer <= 0f)
            {
                isRotating = false;
            }
        }
    }

    public void OpenDoor()
    {
        if (isUnlocked || isRotating) return;

        if (joueurInventaire != null && joueurInventaire.NumberOfKeys >= 1)
        {
            Debug.Log("You have a key! Door will open.");
            isUnlocked = true;
            rotationTimer = rotationDuration;
            isRotating = true;
            joueurInventaire.KeyUsed();
            
            if (audioSource != null && doorOpenSound != null)
                audioSource.PlayOneShot(doorOpenSound);
        }
        else
        {
            if (audioSource != null && doorLockedSound != null)
                audioSource.PlayOneShot(doorLockedSound);
                
            if (chatBubblePrefab != null && chatBubbleAnchor != null)
        {
            ChatBubble.Create(chatBubblePrefab, chatBubbleAnchor, Vector3.zero, noKeyText);
        }
        else
        {
            Debug.LogWarning("ChatBubble prefab or anchor not assigned!");
        }
        }
    }
}
