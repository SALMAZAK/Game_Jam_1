using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform spawnPoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint.position;
    }

    public void WinGame()
    {
        UIManager.Instance.ShowWinScreen(); // تأكد من مطابقة اسم الدالة
    }
}