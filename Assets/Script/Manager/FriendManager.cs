using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public static FriendManager Instance;
    public int totalFriends = 5;
    private int collectedFriends = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectFriend()
    {
        collectedFriends++;
        UIManager.Instance.UpdateScoreUI(collectedFriends);

        if (collectedFriends >= totalFriends)
        {
            GameManager.Instance.WinGame();
        }
    }
}