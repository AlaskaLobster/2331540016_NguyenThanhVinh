using UnityEngine;

public class MusicManager_NguyenThanhVinh : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }
}
