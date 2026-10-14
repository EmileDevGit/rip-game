using UnityEngine;

public class ZoneMusicTrigger : MonoBehaviour
{
    public AudioClip zoneMusic;

    public float musicVolume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(zoneMusic, musicVolume);
        }
    }
}
