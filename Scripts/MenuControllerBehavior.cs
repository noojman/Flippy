using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class MenuControllerBehavior : MonoBehaviour {

    public AudioSource buttonClick;

    public bool inMenu;

    void Awake ()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("73311");
        }
        else
        {
            Debug.Log("Platform not supported for advertisements");
        }
    }

    void Start()
    {
        inMenu = false;

    }

    public void GoToStore ()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("market://details?id=com.noojman.flippy");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.OpenURL("http://www.itunes.com/flippy");
        }
    }

    public void PlayPop()
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            buttonClick.Play();
        }
    }

    public void showAd ()
    {
        Advertisement.Show(null, new ShowOptions
        {
            resultCallback = result =>
            {
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 30);
            }
        });
    }
}