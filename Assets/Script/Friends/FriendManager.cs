using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public List<FriendData> collectedFriends = new List<FriendData>();
    public int totalFriendsToCollect = 5;

    private int collectedCount = 0;

    public void CollectFriend(FriendData friend)
    {
        if (!collectedFriends.Contains(friend))
        {
            collectedFriends.Add(friend);
            collectedCount++;
            Debug.Log($"Collected: {friend.friendName}");
            
            // تحقق من اكتمال عدد الأصدقاء
            if (collectedCount >= totalFriendsToCollect)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        Debug.Log("You Win! All friends have been collected.");
        // استدعاء UI أو أي حدث آخر عند الفوز
        UIManager.Instance.ShowWinScreen();
    }
}