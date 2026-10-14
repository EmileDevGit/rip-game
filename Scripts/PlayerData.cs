using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string playerName;
    public int unlockedLevel = 1;

    private int playerScore = 0; // Score global
    private int sceneScore = 0;  // Score temporaire de la scène

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ---------- NOM ----------
    public void SetPlayerName(string name)
    {
        playerName = name;
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    // ---------- NIVEAU ----------
    public void SetUnlockedLevel(int level)
    {
        if (level > unlockedLevel)
        {
            unlockedLevel = level;
            PlayerPrefs.SetInt("UnlockedLevel", level);
            PlayerPrefs.Save();
        }
    }

    public int GetUnlockedLevel()
    {
        return unlockedLevel;
    }

    // ---------- SCORE GLOBAL ----------
    public int GetTotalScore()
    {
        return playerScore;
    }

    public int GetCurrentScore()
    {
        return playerScore + sceneScore;
    }

    public void AddToTotalScore(int value)
    {
        playerScore += value;
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public void ResetTotalScore()
    {
        playerScore = 0;
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.Save();
    }

    // ---------- SCORE DE LA SCÈNE ----------
    public int GetSceneScore()
    {
        return sceneScore;
    }

    public void AddSceneScore(int value)
    {
        sceneScore += value;
    }

    public void RemoveSceneScore(int value)
    {
        sceneScore -= value;
        if (sceneScore < 0) sceneScore = 0;
    }

    public void ResetSceneScore()
    {
        sceneScore = 0;
    }

    public void CommitSceneScore()
    {
        AddToTotalScore(sceneScore);
        ResetSceneScore();
    }

    // ---------- SAUVEGARDE ----------
    void LoadPlayerData()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "");
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll();
        playerName = "";
        playerScore = 0;
        unlockedLevel = 1;
        sceneScore = 0;
        PlayerPrefs.Save();
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}