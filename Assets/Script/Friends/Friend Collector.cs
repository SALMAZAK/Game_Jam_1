using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    public Transform tableTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // إبلاغ FriendManager بأن اللاعب جمع صديقًا
            FriendManager.Instance.CollectFriend();

            // تشغيل صوت الجمع
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound);

            // إخفاء الصديق
            gameObject.SetActive(false);
        }
    }
}