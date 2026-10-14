using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        JoueurInventaire joueurInventaire = other.GetComponent<JoueurInventaire>();

        if (joueurInventaire != null)
        {
            // Call the method to add the key to the inventory
            if (other.tag == "Flower") joueurInventaire.FlowerCollected();
            else joueurInventaire.KeyCollected();
                gameObject.SetActive(false); // Disable the key object after collection
        }
    }


}
