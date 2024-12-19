using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // العثور على HealthManager الخاص باللاعب
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage); // تقليل صحة اللاعب
               AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDamageSound); 
            }
        }
    }
}
