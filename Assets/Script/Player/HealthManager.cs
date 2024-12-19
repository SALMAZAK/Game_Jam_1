using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealthUI(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UIManager.Instance.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = GameManager.Instance.GetSpawnPoint();
        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealthUI(currentHealth);
    }
}