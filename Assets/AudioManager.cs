using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Sources ----------- ")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("----------- Audio Clips -----------")]
    public AudioClip gameOverJingle;
    public AudioClip stage01Music;
    public AudioClip bossStageMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = stage01Music;
        musicSource.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
