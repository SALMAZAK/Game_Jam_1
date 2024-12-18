using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Vector3 startingPosition; // موقع البداية
    private Rigidbody playerRigidbody;

    void Start()
    {
        currentHealth = maxHealth;
        startingPosition = transform.position; // حفظ موقع البداية
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage()
    {
        currentHealth--;

        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDamageSound);

        if (currentHealth > 0)
        {
            Debug.Log($"Player Health: {currentHealth}");
        }
        else
        {
            Debug.Log("Health depleted. Resetting player.");
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        // إعادة تعيين موقع اللاعب إلى نقطة البداية
        transform.position = startingPosition;
        playerRigidbody.linearVelocity = Vector3.zero;
        currentHealth = maxHealth; // إعادة ضبط الصحة
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}