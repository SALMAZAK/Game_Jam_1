using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

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

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game"); // استبدل بـ اسم مشهد اللعبة
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Main Menu"); // استبدل بـ اسم مشهد القائمة
    }
}