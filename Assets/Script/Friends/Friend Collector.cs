using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    public FriendData friendData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Collected Friend: {friendData.friendName}");
            FindObjectOfType<FriendManager>().CollectFriend(friendData);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound);
            gameObject.SetActive(false); // اختفاء الصديق بعد جمعه
        }
    }
}
