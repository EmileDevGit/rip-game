using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Optional: Keeps music across scenes
    }

    public void PlayMusic(AudioClip clip, float volume)
    {
        if (musicSource.clip == clip)
            return;

        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play();
    }
}
