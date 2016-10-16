using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsPanelBehavior : MonoBehaviour {

    public GameObject controller;
    public GameObject mode;
	public GameObject gameAudio;
	public GameObject vibrate;

	private bool move;
	private int currentPos;
	private float timer;
	private Vector3 startPos;
	
	void Start () {
		if (PlayerPrefs.GetInt ("Lite Mode", 0) == 1) {
			mode.GetComponent<Toggle> ().isOn = true;
            PlayerPrefs.SetInt("Lite Mode", 1);
		} else {
			mode.GetComponent<Toggle> ().isOn = false;
            PlayerPrefs.SetInt("Lite Mode", 0);
        }
		if (PlayerPrefs.GetInt ("Audio", 1) == 1) {
            gameAudio.GetComponent<Toggle> ().isOn = true;
            PlayerPrefs.SetInt("Audio", 1);
        } else {
            gameAudio.GetComponent<Toggle> ().isOn = false;
            PlayerPrefs.SetInt("Audio", 0);
        }
		if (PlayerPrefs.GetInt ("Vibrate", 1) == 1) {
			vibrate.GetComponent<Toggle> ().isOn = true;
            PlayerPrefs.SetInt("Vibrate", 1);
        } else {
			vibrate.GetComponent<Toggle> ().isOn = false;
            PlayerPrefs.SetInt("Vibrate", 0);
        }
		timer = 0.0f;
		startPos = this.GetComponent<RectTransform> ().localPosition;
		currentPos = 1;
		move = false;
	}

    public void ChangePos()
    {
        if (currentPos == 0)
        {
            currentPos = 1;
            if (Application.loadedLevel > 0)
            {
                controller.GetComponent<ControllerBehavior>().inMenu = true;
            }
        }
        else
        {
            currentPos = 0;
            if (Application.loadedLevel > 0)
            {
                controller.GetComponent<ControllerBehavior>().inMenu = true;
            }
        }
        timer = 0.0f;
        move = true;
    }

    public void FlipLiteMode () {
        Debug.Log("flip!");
		if (PlayerPrefs.GetInt("Lite Mode") == 0) {
			PlayerPrefs.SetInt ("Lite Mode", 1);
		} else {
			PlayerPrefs.SetInt ("Lite Mode", 0);
		}
    }

    public void FlipAudio()
    {
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            PlayerPrefs.SetInt("Audio", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 0);
        }
    }

    public void FlipVibrate () {
        if (PlayerPrefs.GetInt("Vibrate") == 0) {
            PlayerPrefs.SetInt ("Vibrate", 1);
		} else {
			PlayerPrefs.SetInt ("Vibrate", 0);
		}
    }
	
	void Update () {
		if (move) {
			if (currentPos == 0) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (this.GetComponent<RectTransform> ().localPosition, new Vector3(0.0f, 0.0f), timer);
                    if (Application.loadedLevel == 0)
                    {
                        timer += Time.deltaTime / 25.0f;
                    }
                    else
                    {
                        timer += Time.deltaTime / 10.0f;
                    }
					if (timer >= 1.0f) {
						move = false;
					}
				}
			}
			if (currentPos == 1) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (this.GetComponent<RectTransform> ().localPosition, startPos, timer);
                    if (Application.loadedLevel == 0)
                    {
                        timer += Time.deltaTime / 25.0f;
                    }
                    else
                    {
                        timer += Time.deltaTime / 10.0f;
                    }
                    if (timer >= 1.0f) {
						move = false;
					}
				}
			}
		}
	}
}