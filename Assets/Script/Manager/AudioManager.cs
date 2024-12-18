using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip jumpSound, collectSound, damageSound, winSound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "JumpSound": audioSource.PlayOneShot(jumpSound); break;
            case "CollectSound": audioSource.PlayOneShot(collectSound); break;
            case "DamageSound": audioSource.PlayOneShot(damageSound); break;
            case "WinSound": audioSource.PlayOneShot(winSound); break;
        }
    }
}