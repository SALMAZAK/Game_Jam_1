using UnityEngine;

public class FriendCollector : MonoBehaviour
{
    public Transform tableTransform; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            MoveToTable();

           
            FriendManager.Instance.CollectFriend();

            
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.collectSound);
        }
    }

    private void MoveToTable()
    {
        if (tableTransform != null)
        {
            transform.position = tableTransform.position; 
            gameObject.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("Table Transform not assigned!");
        }
    }
}