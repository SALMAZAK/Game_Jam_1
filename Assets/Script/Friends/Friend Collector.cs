using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // التأكد من أن FriendManager و AudioManager موجودان
            if (FriendManager.Instance != null)
            {
                FriendManager.Instance.CollectFriend();
            }

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound);
            }

            // إخفاء الصديق بعد جمعه
            gameObject.SetActive(false);
        }
    }
}