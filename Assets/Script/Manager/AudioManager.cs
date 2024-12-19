using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton Instance

    public AudioSource audioSource; // مصدر الصوت الرئيسي
    public AudioClip jumpSound; // صوت القفز
    public AudioClip collectSound; // صوت جمع الأصدقاء
    public AudioClip playerDamageSound; // صوت ضرر اللاعب

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // استمرار الكائن بين المشاهد
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Audio clip or AudioSource is missing!");
        }
    }
}