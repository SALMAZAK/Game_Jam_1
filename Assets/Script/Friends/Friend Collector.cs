using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    public FriendData friendData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<FriendManager>().CollectFriend(friendData);
            AudioManager.Instance.PlaySound("CollectSound");
            gameObject.SetActive(false);
        }
    }
}

