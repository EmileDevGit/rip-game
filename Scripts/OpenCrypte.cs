using UnityEngine;

public class OpenCrypte : MonoBehaviour
{
    public Animator animator;
    public GameObject flowerDetector;
    public FlowerQuestCheck questStatus;
    public bool ready;
    public AudioSource audioSource;
    public JoueurInventaire inventaire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        flowerDetector = GameObject.Find("FlowerDetector");
        questStatus = flowerDetector.GetComponent<FlowerQuestCheck>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inventaire.AmountOfFlowers >= 6) ready = true;
        if (ready) animator.SetBool("IsOpen", true);
        audioSource.Play();
    }
}
