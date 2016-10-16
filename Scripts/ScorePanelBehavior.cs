using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePanelBehavior : MonoBehaviour {
	
	public GameObject controller;
	public GameObject healthBar;
	public GameObject starParticles;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public Button nextLevelButton;

    public AudioSource fairyDust;

    private bool first;
	private bool move;
	private bool end;
	private bool runStars;
	private int currentPos;
	private int starStep;
	private float timer;
	private float starTimer;
	private Vector3 startPos;
	
	void Start () {
		if (Application.loadedLevel == Application.levelCount - 1) {
			nextLevelButton.GetComponentInChildren<Image> ().fillCenter = false;
			nextLevelButton.GetComponentInChildren<Button> ().interactable = false;
		}
        if (Application.loadedLevel == 20 && PlayerPrefs.GetInt("Stage") <= 1)
        {
            nextLevelButton.GetComponentInChildren<Image>().fillCenter = false;
            nextLevelButton.GetComponentInChildren<Button>().interactable = false;
        }
        else if (Application.loadedLevel == 40 && PlayerPrefs.GetInt("Stage") <= 2)
        {
            nextLevelButton.GetComponentInChildren<Image>().fillCenter = false;
            nextLevelButton.GetComponentInChildren<Button>().interactable = false;
        }
        else if (Application.loadedLevel == 60 && PlayerPrefs.GetInt("Stage") <= 3)
        {
            nextLevelButton.GetComponentInChildren<Image>().fillCenter = false;
            nextLevelButton.GetComponentInChildren<Button>().interactable = false;
        }
        else if (Application.loadedLevel == 80 && PlayerPrefs.GetInt("Stage") <= 4)
        {
            nextLevelButton.GetComponentInChildren<Image>().fillCenter = false;
            nextLevelButton.GetComponentInChildren<Button>().interactable = false;
        }
        else if (Application.loadedLevel == 100 && PlayerPrefs.GetInt("Stage") <= 5)
        {
            nextLevelButton.GetComponentInChildren<Image>().fillCenter = false;
            nextLevelButton.GetComponentInChildren<Button>().interactable = false;
        }
        first = true;
		starStep = 1;
		starTimer = 0.0f;
		runStars = false;
		end = false;
		timer = 0.0f;
		startPos = this.GetComponent<RectTransform> ().localPosition;
		currentPos = 1;
		move = false;
	}
	
	public void ChangePos () {
		if (currentPos == 0) {
			currentPos = 1;
            MoPub.destroyBanner();
        } else {
			currentPos = 0;
		}
		timer = 0.0f;
		move = true;
	}

	IEnumerator End () {
        MoPub.createBanner("c73774e554194ff4b1758a9bb517bae4", MoPubAdPosition.BottomCenter);
        yield return new WaitForSeconds(1);
		ChangePos ();
		yield return new WaitForSeconds(1);
		runStars = true;
	}

	void Update() {
		if (controller.GetComponent<ControllerBehavior> ().finished && end == false) {
            StartCoroutine (End ());
			end = true;
		}
        if (runStars)
        {
            if (healthBar.GetComponent<HealthBehavior>().health > PlayerPrefs.GetFloat("Level" + Application.loadedLevel + "Score", 0.0f))
            {
                PlayerPrefs.SetFloat("Level" + Application.loadedLevel + "Score", healthBar.GetComponent<HealthBehavior>().health);
            }
            starTimer += Time.deltaTime / 1.5f;
            if (healthBar.GetComponent<HealthBehavior>().health > 66.0f)
            {
                if (starStep == 1)
                {
                    if (first)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            fairyDust.Play();
                        }
                        first = false;
                    }
                    star1.GetComponent<Image>().color = Color.Lerp(star1.GetComponent<Image>().color, Color.white, starTimer);
                }
                if (star1.GetComponent<Image>().color == Color.white && starStep == 1)
                {
                    first = true;
                    starTimer = 0.0f;
                    starStep++;
                }
                if (starStep == 2)
                {
                    if (first)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            fairyDust.Play();
                        }
                        first = false;
                    }
                    star2.GetComponent<Image>().color = Color.Lerp(star2.GetComponent<Image>().color, Color.white, starTimer);
                }
                if (star2.GetComponent<Image>().color == Color.white && starStep == 2)
                {
                    first = true;
                    starTimer = 0.0f;
                    starStep++;
                }
                if (starStep == 3)
                {
                    if (first)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            fairyDust.Play();
                        }
                        first = false;
                    }
                    star3.GetComponent<Image>().color = Color.Lerp(star3.GetComponent<Image>().color, Color.white, starTimer);
                }
                if (star3.GetComponent<Image>().color == Color.white && starStep == 3)
                {
                    first = true;
                    starParticles.GetComponent<StarParticlesBehavior>().StartParticles();
                    starTimer = 0.0f;
                    starStep++;
                }
            }
            else if (healthBar.GetComponent<HealthBehavior>().health > 33.0f)
            {
                if (starStep == 1)
                {
                    if (first)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            fairyDust.Play();
                        }
                        first = false;
                    }
                    star1.GetComponent<Image>().color = Color.Lerp(star1.GetComponent<Image>().color, Color.white, starTimer);
                }
                if (star1.GetComponent<Image>().color == Color.white && starStep == 1)
                {
                    first = true;
                    starTimer = 0.0f;
                    starStep++;
                }
                if (starStep == 2)
                {
                    if (first)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            fairyDust.Play();
                        }
                        first = false;
                    }
                    star2.GetComponent<Image>().color = Color.Lerp(star2.GetComponent<Image>().color, Color.white, starTimer);
                }
            }
            else if (healthBar.GetComponent<HealthBehavior>().health > 0.0f)
            {
                if (first)
                {
                    if (PlayerPrefs.GetInt("Audio", 1) == 1)
                    {
                        fairyDust.Play();
                    }
                    first = false;
                }
                star1.GetComponent<Image>().color = Color.Lerp(star1.GetComponent<Image>().color, Color.white, starTimer);
            }
        }
        if (move) {
			if (currentPos == 0) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (this.GetComponent<RectTransform> ().localPosition, new Vector3(0.0f, 0.0f), timer);
					timer += Time.deltaTime / 10.0f;
					if (timer >= 1.0f) {
						move = false;
					}
				}
			}
			if (currentPos == 1) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (this.GetComponent<RectTransform> ().localPosition, startPos, timer);
					timer += Time.deltaTime / 10.0f;
					if (timer >= 1.0f) {
						move = false;
					}
				}
			}
		}
	}
}