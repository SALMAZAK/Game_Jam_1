using UnityEngine;

public class Friend : MonoBehaviour
{
    private FriendManager friendManager;

    private void Start()
    {
        friendManager = FindObjectOfType<FriendManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound); // تشغيل صوت جمع الصديق
            friendManager.CollectFriend(gameObject); // إبلاغ FriendManager
        }
    }
}