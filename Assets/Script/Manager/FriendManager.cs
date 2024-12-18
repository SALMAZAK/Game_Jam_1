using UnityEngine;
using System.Collections.Generic;

public class FriendManager : MonoBehaviour
{
    public List<FriendData> collectedFriends = new List<FriendData>();
    public UIManager uiManager;

    public void CollectFriend(FriendData friend)
    {
        if (!collectedFriends.Contains(friend))
        {
            collectedFriends.Add(friend);
            uiManager.UpdateScoreUI(collectedFriends.Count);

            if (collectedFriends.Count >= 5)
            {
                uiManager.ShowWinScreen();
            }
        }
    }
}