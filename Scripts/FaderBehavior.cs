using UnityEngine;
using System.Collections;

public class FaderBehavior : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject menuPanel2;

	private GUITexture myTexture;

	public float fadeSpeed = 1.5f;

    private bool exit = false;
	private bool sceneStarting = true;
	private bool sceneEnding = false;
	private bool restart = false;
	private bool menu = false;
	private bool next = false;
	private bool goLevel = false;
	private int level = 0;

    void Start ()
    {
        myTexture = this.GetComponent<GUITexture>();
        myTexture.pixelInset = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
    }

	void Update () {
		if (sceneStarting) {
            myTexture.color = Color.Lerp (myTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
			if (myTexture.color.a <= 0.05f) {
                myTexture.color = Color.clear;
                myTexture.enabled = false;
				sceneStarting = false;
			}
		}
		if (sceneEnding) {
            myTexture.color = Color.Lerp (myTexture.color, Color.black, fadeSpeed * Time.deltaTime);
			if (myTexture.color.a >= 0.95f) {
				if (next) {
					Application.LoadLevel (Application.loadedLevel + 1);
				} else if (restart) {
					Application.LoadLevel (Application.loadedLevel);
				} else if (menu) {
					Application.LoadLevel (0);
				} else if (goLevel) {
					Application.LoadLevel(level);
				} else if (exit)
                {
                    Application.Quit();
                }
			}
		}
	}

    public void ExitGame ()
    {
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(2);
        myTexture.enabled = true;
        sceneEnding = true;
        exit = true;
        restart = false;
        menu = false;
        next = false;
        goLevel = false;
    }

    public void DeathRestart ()
    {
		StartCoroutine (End ());
	}

	IEnumerator End () {
		yield return new WaitForSeconds(2);
        myTexture.enabled = true;
		sceneEnding = true;
        exit = false;
        restart = true;
		menu = false;
		next = false;
		goLevel = false;
	}

	public void RestartScene () {
        myTexture.enabled = true;
		sceneEnding = true;
        exit = false;
        restart = true;
		menu = false;
		next = false;
		goLevel = false;
	}

	public void GoToLevel (int lvl) {
		StartCoroutine (GoTo (lvl));
	}

	IEnumerator GoTo (int lvl) {
        menuPanel.GetComponent<MenuPanelBehavior>().ChangePos();
        menuPanel2.GetComponent<MenuPanel2Behavior>().ChangePos();
        if (PlayerPrefs.GetInt("Vibrate") == 1) {
			Handheld.Vibrate ();
		}
		yield return new WaitForSeconds (1);
        myTexture.enabled = true;
		sceneEnding = true;
        exit = false;
        goLevel = true;
		level = lvl;
		menu = false;
		next = false;
		restart = false;
	}

	public void GoToMenu () {
        myTexture.enabled = true;
		sceneEnding = true;
        exit = false;
        menu = true;
		restart = false;
		next = false;
		goLevel = false;
	}

	public void NextLevel () {
        myTexture.enabled = true;
		sceneEnding = true;
        exit = false;
        next = true;
		menu = false;
		restart = false;
		goLevel = false;
	}
}
