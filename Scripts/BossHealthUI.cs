using UnityEngine;
using UnityEngine.UI;
public class BossHealthUI : MonoBehaviour
{
    public Slider slider;
    public Enemy enemy;

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    void FixedUpdate()
    {
        slider.value = enemy.currentHealth;
    }
}
