using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text livesText;
    public Text friendsText;
    public Text scoreText; // إضافة UI للسكور
    public GameObject winScreen;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateLivesUI(int currentLives)
    {
        livesText.text = $"Lives: {currentLives}";
    }

    public void UpdateFriendsUI(int collected, int total)
    {
        friendsText.text = $"Friends: {collected}/{total}";
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = $"Score: {score}"; 
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}