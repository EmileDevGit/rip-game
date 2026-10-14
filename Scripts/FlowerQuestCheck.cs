using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class FlowerQuestCheck : MonoBehaviour
{
    //Liste des fleurs à récolter
    public GameObject[] flowers;
    //Nombre de fleurs dans la zone
    [SerializeField] int _amountInside;
    //Zone de détection de fleurs
    [SerializeField] List<GameObject> _detectedFlowers;
    //Détermine si la crypte doit s'ouvrir
    public bool _isCrypteOpen;
    public JoueurInventaire inventaire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _detectedFlowers = new List<GameObject>();
        _isCrypteOpen = false;
    }

    private void FixedUpdate()
    {
        _amountInside = _detectedFlowers.Count;
        if (_amountInside >= flowers.Length || inventaire.AmountOfFlowers >= flowers.Length)
        {
            _isCrypteOpen = true;
        }
    }

    //Collider is inside
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            bool _alreadyIn = false;
            foreach (GameObject item in _detectedFlowers)
            {
                if (other.gameObject.name == item.name) _alreadyIn = true;
            }
            if (!_alreadyIn) _detectedFlowers.Add(other.gameObject);
        }

    }
}
