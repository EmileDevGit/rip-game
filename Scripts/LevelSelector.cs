using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [System.Serializable]
    public class LevelButton
    {
        public Button button;
        public int levelIndex; // 1 = niveau 1, 2 = niveau 2, etc.
    }

    public LevelButton[] levelButtons;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Par défaut : seul niveau 1 débloqué

        foreach (LevelButton lb in levelButtons)
        {
            bool isUnlocked = lb.levelIndex <= unlockedLevel;
            lb.button.interactable = isUnlocked;
        }
    }
}