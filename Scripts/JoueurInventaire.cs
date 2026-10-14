using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class JoueurInventaire : MonoBehaviour
{
    public int NumberOfKeys { get; private set; }
    public int NumberOfFlowers { get; private set; }
    public int AmountOfFlowers;

    public UnityEvent<JoueurInventaire> OnKeyCollected; // Event to notify when a key is collecteds
    public UnityEvent<JoueurInventaire> OnFlowerCollected;

    public AudioSource pickupAudio;

    public void KeyCollected()
    {
        NumberOfKeys++;
        OnKeyCollected.Invoke(this); // Invoke the event to notify subscribers
        pickupAudio.Play();

    }

    public void KeyUsed()
    {
        NumberOfKeys--;
        OnKeyCollected.Invoke(this);
    }

    public void FlowerCollected()
    {
        NumberOfFlowers++;
        OnFlowerCollected.Invoke(this);
        pickupAudio.Play();
    }

    public void FlowerPlaced()
    {
        NumberOfFlowers--;
        OnFlowerCollected.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower") AmountOfFlowers++;
        pickupAudio.Play();
    }
}
