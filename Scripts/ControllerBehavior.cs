using UnityEngine;
using System.Collections;

public class ControllerBehavior : MonoBehaviour {

    public AudioSource buttonPop;
    public AudioSource explode;
    public AudioSource debris;

    public int level;
    
	public bool inMenu;
	public bool finished;

	// Use this for initialization
	void Start () {
        level = Application.loadedLevel;
		inMenu = false;
		finished = false;
	}

    public void PlayPop ()
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            buttonPop.Play();
        }
    }

    public void PlayExplode ()
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            explode.Play();
            debris.Play();
        }
    }
}
