using System;
using Unity.VisualScripting;
using UnityEngine;

public class ReachedEternalRest : MonoBehaviour
{
    public static event Action OnPlayerWin;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip trueGameOver;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            audioSource.PlayOneShot(trueGameOver);
            RestInPeace();
        }
    }

    public static void RestInPeace()
    {
        OnPlayerWin.Invoke();
        
        
    }
}
