using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;
    public BossHealthUI bossHealthUI;
    public Collider2D gotoNextLevel;

    public static bool isDead = false;


    void Start()
    {
        currentHealth = maxHealth;

    }

    public void Die()
    {
        bossHealthUI.gameObject.SetActive(false);
        gotoNextLevel.isTrigger = true;
        PlayerData.Instance.AddSceneScore(1375);
    }
}
