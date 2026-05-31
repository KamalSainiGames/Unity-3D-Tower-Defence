using UnityEngine;
using UnityEngine.UI;

public class TableSetting : MonoBehaviour
{
    [Header("UI")]
   

    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;

    [SerializeField] private GameObject musicOn;
    [SerializeField] private GameObject musicOff;

    private bool isSoundOn;
    private bool isMusicOn;

    private void Start()
    {
        isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        isMusicOn = PlayerPrefs.GetInt("Music", 1) == 1;

        UpdateUI();      
    }

    public void ToggleSound(bool value)
    {
        isSoundOn = value;

        AudioListener.volume = isSoundOn ? 1f : 0f;

        PlayerPrefs.SetInt("Sound", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateUI();
    }

    public void ToggleMusic(bool value)
    {
        isMusicOn = value;

        PlayerPrefs.SetInt("Music", isMusicOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateUI();
    }

    private void UpdateUI()
    {
        soundOn.SetActive(isSoundOn);
        soundOff.SetActive(!isSoundOn);

        musicOn.SetActive(isMusicOn);
        musicOff.SetActive(!isMusicOn);
    }
}
