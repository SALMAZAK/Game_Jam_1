using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public static FriendManager Instance;

    public int totalFriends = 5; // العدد الإجمالي للأصدقاء
    private int collectedFriends = 0; // عدد الأصدقاء الذين تم جمعهم
    public Transform friendTable; // مكان ظهور الأصدقاء عند جمعهم

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

    private void Update()
    {
        // اختصار لجمع جميع الأصدقاء بالضغط على مفتاح "G"
        if (Input.GetKeyDown(KeyCode.G))
        {
            CollectAllFriends();
        }
    }

    public void CollectFriend()
    {
        collectedFriends++;
        UIManager.Instance.UpdateScoreUI(collectedFriends);

        if (collectedFriends >= totalFriends)
        {
            Debug.Log("All friends collected!");
            TriggerWinSequence();
        }
    }

    public void CollectAllFriends()
    {
        collectedFriends = totalFriends;
        UIManager.Instance.UpdateScoreUI(collectedFriends);
        TriggerWinSequence();
    }

    private void TriggerWinSequence()
    {
        UIManager.Instance.ShowWinScreen();
        // إضافة تأثير الألعاب النارية هنا
        // يمكن تشغيل صوت أو تفعيل أي Animation خاص بالفوز
        Invoke("ReturnToMenu", 20f); // العودة للقائمة بعد 20 ثانية
    }

    private void ReturnToMenu()
    {
        SceneTransitionManager.Instance.LoadMenuScene();
    }
}