using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText; // نص يعرض عدد الأصدقاء
    public TextMeshProUGUI healthText; // نص يعرض عدد الأرواح
    public GameObject winScreen; // شاشة الفوز

    private int initialScore = 0; // القيمة الأولية لعدد الأصدقاء
    private int initialHealth = 3; // القيمة الأولية لعدد الأرواح

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
        // تحديث النصوص بالقيم الأولية عند بدء اللعبة
        UpdateScoreUI(initialScore);
        UpdateHealthUI(initialHealth);
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Friends Collected:{score}/5";
        }
    }

    public void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"Lives: {currentHealth}";
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