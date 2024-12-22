using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform spawnPoint;
    public GameObject player;

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

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint.position;
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

    public void WinGame()
    {
        UIManager.Instance.ShowWinScreen();
        ReturnPlayerToSpawn();
    }
}