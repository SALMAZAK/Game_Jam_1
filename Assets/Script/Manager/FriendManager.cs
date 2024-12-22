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
        if (fireworksEffect != null)
        {
            fireworksEffect.Stop();
        }
    }

    private void Update()
    {
        // اختبار بالاختصار (L) لتشغيل جميع الأحداث
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Test Mode: Trigger all actions!");

            collectedFriends = totalFriends;
            UIManager.Instance.UpdateScoreUI(collectedFriends);

            ShowFireworks();
            GameManager.Instance.ReturnPlayerToSpawn();
            UIManager.Instance.ShowWinScreen();
        }
    }

    public void CollectFriend()
    {
        collectedFriends++;
        UIManager.Instance.UpdateScoreUI(collectedFriends);

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

        if (fireworksEffect != null)
        {
            fireworksEffect.Play();
        }

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