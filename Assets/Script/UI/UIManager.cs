using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI healthText; 
    public GameObject winScreen; 

    private int initialScore = 0; 
    private int initialHealth = 3; 

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
        if (winScreen != null)
        {
            winScreen.SetActive(false); // إخفاء شاشة الفوز عند بدء اللعبة
        }

        UpdateScoreUI(initialScore);
        UpdateHealthUI(initialHealth);
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Friends Collected: {score}/10";
        }
    }

    public void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}";
        }
    }

    public void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true); // عرض شاشة الفوز
        }
    }
}