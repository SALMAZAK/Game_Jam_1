using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public static FriendManager Instance;

    public int totalFriends = 10; 
    private int collectedFriends = 0;

    public ParticleSystem fireworksEffect; 
    public AudioClip fireworksSound; 

    private bool hasShownFireworks = false; 

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

    private void Start()
    {
        // إيقاف تأثير الألعاب النارية في البداية
        if (fireworksEffect != null)
        {
            fireworksEffect.Stop();
        }
    }

    private void Update()
    {
        // اختبار بالاختصار (L) لجمع كل الأصدقاء
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Test Mode: All friends collected!");
            collectedFriends = totalFriends; 
            UIManager.Instance.UpdateScoreUI(collectedFriends);
            CheckAllFriendsCollected();
        }
    }

    public void CollectFriend()
    {
        collectedFriends++;
        UIManager.Instance.UpdateScoreUI(collectedFriends);

        // تحقق إذا تم جمع جميع الأصدقاء
        CheckAllFriendsCollected();
    }

    private void CheckAllFriendsCollected()
    {
        if (collectedFriends >= totalFriends && !hasShownFireworks)
        {
            ShowFireworks();
        }
    }

    private void ShowFireworks()
    {
        if (hasShownFireworks) return; 
        hasShownFireworks = true;

        // تشغيل الألعاب النارية
        if (fireworksEffect != null)
        {
            fireworksEffect.Play();
        }

        // تشغيل صوت الألعاب النارية
        if (AudioManager.Instance != null && fireworksSound != null)
        {
            AudioManager.Instance.PlaySoundEffect(fireworksSound);
        }

       
        Invoke(nameof(ReturnToMenu), 10f);
    }

    private void ReturnToMenu()
    {
        SceneTransitionManager.Instance.LoadMenuScene();
    }
}
