using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    public Transform tableTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            MoveToT


            FriendManager.Instance.CollectFriend();


            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound);
        }
    }

}