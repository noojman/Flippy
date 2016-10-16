using UnityEngine;
using System.Collections;

public class MenuLightsBehavior : MonoBehaviour {

	public GameObject myCamera;

	public GameObject optionsLight;
	public GameObject playLight;
	public GameObject birdLight;
	public GameObject signLight;

	public GameObject LevelsLight1;
	public GameObject LevelsLight2;
	public GameObject LevelsLight3;
	public GameObject LevelsLight4;
	public GameObject LevelsLight5;

	public GameObject unlockLight1;
	public GameObject unlockLight2;
	public GameObject unlockLight3;
	public GameObject unlockLight4;
	public GameObject unlockLight5;

	private bool optionsLightUp;
	private bool playLightUp;
	private bool birdLightUp;
	private bool signLightUp;
	private bool LevelsLight1Up;
	private bool LevelsLight2Up;
	private bool LevelsLight3Up;
	private bool LevelsLight4Up;
	private bool LevelsLight5Up;

	private bool optionsLightDown;
	private bool playLightDown;
	private bool birdLightDown;
	private bool signLightDown;
	private bool LevelsLight1Down;
	private bool LevelsLight2Down;
	private bool LevelsLight3Down;
	private bool LevelsLight4Down;
	private bool LevelsLight5Down;

	private float optionsIntensity;
	private float playIntensity;
	private float birdIntensity;
	private float signIntensity;
	private float levelsIntensity;

	public float timer;

	public float rateDivider;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		optionsIntensity = 4.25f;
		playIntensity = 3.0f;
		birdIntensity = 2.0f;
		signIntensity = 5.5f;
		levelsIntensity = 4.0f;
		optionsLightUp = true;
		playLightUp = true;
		birdLightUp = true;
		signLightUp = true;
		LevelsLight1Up = false;
		LevelsLight2Up = false;
		LevelsLight3Up = false;
		LevelsLight4Up = false;
		LevelsLight5Up = false;
		optionsLightDown = false;
		playLightDown = false;
		birdLightDown = false;
		signLightDown = false;
		LevelsLight1Down = true;
		LevelsLight2Down = true;
		LevelsLight3Down = true;
		LevelsLight4Down = true;
		LevelsLight5Down = true;
	}

	public void ChangeTo (int pos) {
		if (pos == -2) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = true;
			signLightUp = false;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = false;
			signLightDown = true;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == -1) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = false;
			signLightUp = true;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = true;
			signLightDown = false;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == 0) {
			optionsLightUp = true;
			playLightUp = true;
			birdLightUp = true;
			signLightUp = true;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = false;
			playLightDown = false;
			birdLightDown = false;
			signLightDown = false;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == 1) {
			optionsLightUp = true;
			playLightUp = true;
			birdLightUp = false;
			signLightUp = false;
            LevelsLight1Up = true;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = false;
			playLightDown = false;
			birdLightDown = true;
			signLightDown = true;
			LevelsLight1Down = false;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == 2) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = false;
			signLightUp = false;
			LevelsLight1Up = false;
			LevelsLight2Up = true;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = true;
			signLightDown = true;
			LevelsLight1Down = true;
			LevelsLight2Down = false;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == 3) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = false;
			signLightUp = false;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = true;
			LevelsLight4Up = false;
			LevelsLight5Up = false;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = true;
			signLightDown = true;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = false;
			LevelsLight4Down = true;
			LevelsLight5Down = true;
		}
		if (pos == 4) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = false;
			signLightUp = false;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = true;
			LevelsLight5Up = false;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = true;
			signLightDown = true;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = false;
			LevelsLight5Down = true;
		}
		if (pos == 5) {
			optionsLightUp = false;
			playLightUp = false;
			birdLightUp = false;
			signLightUp = false;
			LevelsLight1Up = false;
			LevelsLight2Up = false;
			LevelsLight3Up = false;
			LevelsLight4Up = false;
			LevelsLight5Up = true;
			optionsLightDown = true;
			playLightDown = true;
			birdLightDown = true;
			signLightDown = true;
			LevelsLight1Down = true;
			LevelsLight2Down = true;
			LevelsLight3Down = true;
			LevelsLight4Down = true;
			LevelsLight5Down = false;
		}
		timer = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (optionsLightUp) {
			timer += Time.deltaTime / rateDivider;
			optionsLight.GetComponent<Light> ().intensity = Mathf.Lerp (optionsLight.GetComponent<Light> ().intensity, optionsIntensity, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				optionsLightUp = false;
				optionsLight.GetComponent<Light> ().intensity = optionsIntensity;
			}
		}
		if (optionsLightDown) {
			timer += Time.deltaTime / rateDivider;
			optionsLight.GetComponent<Light> ().intensity = Mathf.Lerp (optionsLight.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				optionsLightDown = false;
				optionsLight.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (playLightUp) {
			timer += Time.deltaTime / rateDivider;
			playLight.GetComponent<Light> ().intensity = Mathf.Lerp (playLight.GetComponent<Light> ().intensity, playIntensity, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				playLightUp = false;
				playLight.GetComponent<Light> ().intensity = playIntensity;
			}
		}
		if (playLightDown) {
			timer += Time.deltaTime / rateDivider;
			playLight.GetComponent<Light> ().intensity = Mathf.Lerp (playLight.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				playLightDown = false;
				playLight.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (birdLightUp) {
			timer += Time.deltaTime / rateDivider;
			birdLight.GetComponent<Light> ().intensity = Mathf.Lerp (birdLight.GetComponent<Light> ().intensity, birdIntensity, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				birdLightUp = false;
				birdLight.GetComponent<Light> ().intensity = birdIntensity;
			}
		}
		if (birdLightDown) {
			timer += Time.deltaTime / rateDivider;
			birdLight.GetComponent<Light> ().intensity = Mathf.Lerp (birdLight.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				birdLightDown = false;
				birdLight.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (signLightUp) {
			timer += Time.deltaTime / rateDivider;
			signLight.GetComponent<Light> ().intensity = Mathf.Lerp (signLight.GetComponent<Light> ().intensity, signIntensity, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				signLightUp = false;
				signLight.GetComponent<Light> ().intensity = signIntensity;
			}
		}
		if (signLightDown) {
			timer += Time.deltaTime / rateDivider;
			signLight.GetComponent<Light> ().intensity = Mathf.Lerp (signLight.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				signLightDown = false;
				signLight.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (LevelsLight1Up) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight1.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight1.GetComponent<Light> ().intensity, levelsIntensity, timer);
            if (PlayerPrefs.GetInt("Stage", 1) == 1)
            {
                unlockLight1.GetComponent<Light>().intensity = Mathf.Lerp(unlockLight1.GetComponent<Light>().intensity, playIntensity, timer);
            }
            if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight1Up = false;
                if (PlayerPrefs.GetInt("Stage", 1) == 1)
                {
                    unlockLight1.GetComponent<Light>().intensity = playIntensity;
                }
				LevelsLight1.GetComponent<Light> ().intensity = levelsIntensity;
			}
		}
		if (LevelsLight1Down) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight1.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight1.GetComponent<Light> ().intensity, 0.0f, timer);
			unlockLight1.GetComponent<Light> ().intensity = Mathf.Lerp (unlockLight1.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight1Down = false;
				LevelsLight1.GetComponent<Light> ().intensity = 0.0f;
				unlockLight1.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (LevelsLight2Up) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight2.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight2.GetComponent<Light> ().intensity, levelsIntensity, timer);
            if (PlayerPrefs.GetInt("Stage", 1) == 2)
            {
                unlockLight2.GetComponent<Light>().intensity = Mathf.Lerp(unlockLight2.GetComponent<Light>().intensity, playIntensity, timer);
            }
            if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight2Up = false;
                if (PlayerPrefs.GetInt("Stage", 1) == 2)
                {
                    unlockLight2.GetComponent<Light>().intensity = playIntensity;
                }
				LevelsLight2.GetComponent<Light> ().intensity = levelsIntensity;
			}
		}
		if (LevelsLight2Down) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight2.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight2.GetComponent<Light> ().intensity, 0.0f, timer);
			unlockLight2.GetComponent<Light> ().intensity = Mathf.Lerp (unlockLight2.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight2Down = false;
				LevelsLight2.GetComponent<Light> ().intensity = 0.0f;
				unlockLight2.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (LevelsLight3Up) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight3.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight3.GetComponent<Light> ().intensity, levelsIntensity, timer);
            if (PlayerPrefs.GetInt("Stage", 1) == 3)
            {
                unlockLight3.GetComponent<Light>().intensity = Mathf.Lerp(unlockLight3.GetComponent<Light>().intensity, playIntensity, timer);
            }
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight3Up = false;
                if (PlayerPrefs.GetInt("Stage", 1) == 3)
                {
                    unlockLight3.GetComponent<Light>().intensity = playIntensity;
                }
				LevelsLight3.GetComponent<Light> ().intensity = levelsIntensity;
			}
		}
		if (LevelsLight3Down) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight3.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight3.GetComponent<Light> ().intensity, 0.0f, timer);
			unlockLight3.GetComponent<Light> ().intensity = Mathf.Lerp (unlockLight3.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight3Down = false;
				LevelsLight3.GetComponent<Light> ().intensity = 0.0f;
				unlockLight3.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (LevelsLight4Up) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight4.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight4.GetComponent<Light> ().intensity, levelsIntensity, timer);
            if (PlayerPrefs.GetInt("Stage", 1) == 4)
            {
                unlockLight4.GetComponent<Light>().intensity = Mathf.Lerp(unlockLight4.GetComponent<Light>().intensity, playIntensity, timer);
            }
            if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight4Up = false;
                if (PlayerPrefs.GetInt("Stage", 1) == 4)
                {
                    unlockLight4.GetComponent<Light>().intensity = playIntensity;
                }
				LevelsLight4.GetComponent<Light> ().intensity = levelsIntensity;
			}
		}
		if (LevelsLight4Down) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight4.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight4.GetComponent<Light> ().intensity, 0.0f, timer);
			unlockLight4.GetComponent<Light> ().intensity = Mathf.Lerp (unlockLight4.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight4Down = false;
				LevelsLight4.GetComponent<Light> ().intensity = 0.0f;
				unlockLight4.GetComponent<Light> ().intensity = 0.0f;
			}
		}

		if (LevelsLight5Up) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight5.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight5.GetComponent<Light> ().intensity, levelsIntensity, timer);
            if (PlayerPrefs.GetInt("Stage", 1) == 5)
            {
                unlockLight5.GetComponent<Light>().intensity = Mathf.Lerp(unlockLight5.GetComponent<Light>().intensity, playIntensity, timer);
            }
            if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight5Up = false;
                if (PlayerPrefs.GetInt("Stage", 1) == 5)
                {
                    unlockLight5.GetComponent<Light>().intensity = playIntensity;
                }
				LevelsLight5.GetComponent<Light> ().intensity = levelsIntensity;
			}
		}
		if (LevelsLight5Down) {
			timer += Time.deltaTime / rateDivider;
			LevelsLight5.GetComponent<Light> ().intensity = Mathf.Lerp (LevelsLight5.GetComponent<Light> ().intensity, 0.0f, timer);
			unlockLight5.GetComponent<Light> ().intensity = Mathf.Lerp (unlockLight5.GetComponent<Light> ().intensity, 0.0f, timer);
			if (timer >= 0.9f) {
				timer = 0.0f;
				LevelsLight5Down = false;
				LevelsLight5.GetComponent<Light> ().intensity = 0.0f;
				unlockLight5.GetComponent<Light> ().intensity = 0.0f;
			}
		}
	}
}
