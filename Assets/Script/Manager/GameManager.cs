using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform spawnPoint;
    public GameObject player;

    [HideInInspector]
    public bool isGameOver = false;

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

    public void ReturnPlayerToSpawn()
    {
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowLoseScreen();
        }

        if (player != null)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Invoke(nameof(ReturnToMenu), 5f);
    }

    public void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowWinScreen();
        }

        ReturnPlayerToSpawn();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ReturnToMenu()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.LoadMenuScene();
        }
    }
}
