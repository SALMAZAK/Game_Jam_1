using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance; // Singleton Instance

    public TextMeshProUGUI scoreText;
    public GameObject[] healthIcons;
    public GameObject winScreen;

    private void Awake()
    {
        // تحقق من عدم وجود نسخة سابقة لـ UIManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // تجنب وجود أكثر من نسخة
        }
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Friends Collected: {score}/5";
        }
    }

    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].SetActive(i < currentHealth);
        }
    }

    public void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
    }
}