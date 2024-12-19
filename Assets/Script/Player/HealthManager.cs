using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3; // الحد الأقصى للصحة
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealthUI(currentHealth); // تحديث واجهة الصحة عند بدء اللعبة
    }

    public void TakeDamage()
    {
        currentHealth--;
        UIManager.Instance.UpdateHealthUI(currentHealth); // تحديث واجهة الصحة عند الضرر

        if (currentHealth <= 0)
        {
            RespawnPlayer(); // استدعاء إعادة الإحياء
        }
    }

    private void RespawnPlayer()
    {
        transform.position = GameManager.Instance.GetSpawnPoint(); // إعادة تعيين الموقع
        currentHealth = maxHealth; // إعادة ضبط الصحة
        UIManager.Instance.UpdateHealthUI(currentHealth); // تحديث الصحة إلى الحالة الكاملة
    }
}