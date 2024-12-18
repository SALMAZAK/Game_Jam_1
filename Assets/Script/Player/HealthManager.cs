using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateHealthUI(currentHealth);
    }

    public void TakeDamage()
    {
        currentHealth--;
        uiManager.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        transform.position = Vector3.zero; // إعادة اللاعب لنقطة البداية
        currentHealth = maxHealth;
        uiManager.UpdateHealthUI(currentHealth);
    }
}