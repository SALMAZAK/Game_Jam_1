using UnityEngine;

[CreateAssetMenu(fileName = "NewFriend", menuName = "Game/Friend")]
public class FriendData : ScriptableObject
{
    public FriendType friendType;
    public string friendName;
    public Sprite friendIcon;
    public GameObject friendPrefab;
}

    
 

 

