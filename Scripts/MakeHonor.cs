using UnityEngine;

public class MakeHonor : MonoBehaviour
{
    public JoueurInventaire inventaire;
    private bool hasFlower = false;
    [SerializeField] private string noFlowerText = "Gimme Flowers!";
    [SerializeField] private string interactText;
    
    public string GetInteractText()
    {
        return interactText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveFlower()
    {
        if (inventaire != null &&  inventaire.NumberOfFlowers >= 1)
        {
            Debug.Log("Thank you for the flowers!");
            hasFlower = true;
            inventaire.FlowerPlaced();
        }
    }
}
