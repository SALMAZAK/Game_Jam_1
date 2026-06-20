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
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Test Mode: Trigger all actions!");
            collectedFriends = totalFriends;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateScoreUI(collectedFriends);
            }
            TriggerAllEvents();
        }
    }

    public void CollectFriend()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        collectedFriends++;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScoreUI(collectedFriends);
        }

        CheckAllFriendsCollected();
    }

    private void CheckAllFriendsCollected()
    {
        if (collectedFriends >= totalFriends && !hasShownFireworks)
        {
            TriggerAllEvents();
        }
    }

    private void TriggerAllEvents()
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

        if (GameManager.Instance != null)
        {
            GameManager.Instance.WinGame();
        }

        Invoke(nameof(ReturnToMenu), 10f);
    }

    private void ReturnToMenu()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.LoadMenuScene();
        }
    }
}
