using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton Instance

    public AudioSource audioSource; 
    public AudioClip jumpSound; 
    public AudioClip collectSound; 
    public AudioClip playerDamageSound; 
    public AudioClip backgroundMusic; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
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

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; 
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music or AudioSource is missing!");
        }
    }
}