using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private InputField inputFieldRocketSpeed;

    private void Start()
    {
        SetSoundAtStart();
        SetSpeedAtStart();
    }

    public void OnSoundToggleValueChanged()
    {
        if (soundToggle.isOn)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
        PlayerPrefs.SetFloat("Sound", AudioListener.volume);
    }

    public void OnInputFieldRocketSpeedChanged()
    {
        GameManager.Instance.rocketFlySpeeed = float.Parse(inputFieldRocketSpeed.text);
        PlayerPrefs.SetFloat("Speed", GameManager.Instance.rocketFlySpeeed);
    }

    private void SetSoundAtStart()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Sound");
            if (AudioListener.volume != 0)
            {
                soundToggle.isOn = true;
            }
            else
            {
                soundToggle.isOn = false;
            }
        }
    }

    private void SetSpeedAtStart()
    {
        if (PlayerPrefs.HasKey("Speed"))
        {
            GameManager.Instance.rocketFlySpeeed = PlayerPrefs.GetFloat("Speed");
            inputFieldRocketSpeed.text = GameManager.Instance.rocketFlySpeeed.ToString();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
