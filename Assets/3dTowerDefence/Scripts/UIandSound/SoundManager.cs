using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip bgMusic;
    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip victoryClip;
    [SerializeField] private AudioClip defeatClip;
    [SerializeField] private AudioClip buttonClickClip;

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

    private void Start()
    {
        PlayBGMusic();
    }

    public void PlayBGMusic()
    {
        if (musicSource == null || bgMusic == null) return;

        musicSource.clip = bgMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayAttack()
    {
        PlaySFX(attackClip);
    }

    public void PlayVictory()
    {
        PlaySFX(victoryClip);
    }

    public void PlayDefeat()
    {
        PlaySFX(defeatClip);
    }

    public void PlayButtonClick()
    {
        PlaySFX(buttonClickClip);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
            sfxSource.PlayOneShot(clip);
    }
}