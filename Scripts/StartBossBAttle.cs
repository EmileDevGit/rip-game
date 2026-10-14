using UnityEngine;

public class StartBossBAttle : MonoBehaviour
{
    public BossHealthUI bossHealthUI;
    void OnTriggerEnter2D(Collider2D collision)
    {
        bossHealthUI.gameObject.SetActive(true);
    }
}
