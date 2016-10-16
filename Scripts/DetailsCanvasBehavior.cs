using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetailsCanvasBehavior : MonoBehaviour {

	public GameObject player;
	public GameObject myCamera;
	public GameObject panel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	public int starStep;
	private float starTimer;
	private float score;

    Color lightRed = new Color(248.0f / 255.0f, 118.0f / 255.0f, 118.0f / 255.0f, 1.0f);
    Color lightGreen = new Color(128.0f / 255.0f, 1.0f, 149.0f / 255.0f, 1.0f);

	void Start () {
		if (PlayerPrefs.GetInt ("Block Number", 1) < player.GetComponent <MenuPlayerBehavior> ().blockNumber) {
            panel.GetComponent<Image>().color = lightRed;
		} else {
            panel.GetComponent<Image>().color = lightGreen;
        }
		starStep = 1;
		starTimer = 0.0f;
		star1.GetComponent<Image> ().color = Color.black;
		star2.GetComponent<Image> ().color = Color.black;
		star3.GetComponent<Image> ().color = Color.black;
	}

	public void EnableCanvas () {
		this.GetComponent <Canvas> ().enabled = true;
	}

	public void Reset () {
		if (PlayerPrefs.GetInt ("Block Number", 1) < player.GetComponent <MenuPlayerBehavior> ().blockNumber) {
            panel.GetComponent<Image>().color = lightRed;
        } else {
            panel.GetComponent<Image>().color = lightGreen;
        }
		starStep = 1;
		starTimer = 0.0f;
		star1.GetComponent<Image> ().color = Color.black;
		star2.GetComponent<Image> ().color = Color.black;
		star3.GetComponent<Image> ().color = Color.black;
	}

    void Update () {
        transform.position = player.transform.position;

        if (myCamera.GetComponent <MenuCameraBehavior> ().currentPos < 1) {
			this.GetComponent <Canvas> ().enabled = false;
		}

		score = PlayerPrefs.GetFloat ("Level" + player.GetComponent <MenuPlayerBehavior> ().blockNumber + "Score", 0);

		starTimer += Time.deltaTime * 8.0f;
		if (score <= 33.0f && score > 0.0f) {
			star1.GetComponent<Image> ().color = Color.Lerp (star1.GetComponent<Image> ().color, Color.white, starTimer);
		} else if (score <= 66.0f && score > 0.0f) {
			if (starStep == 1) {
				star1.GetComponent<Image> ().color = Color.Lerp (star1.GetComponent<Image> ().color, Color.white, starTimer);
			}
			if (star1.GetComponent<Image> ().color == Color.white && starStep == 1) {
				starTimer = 0.0f;
				starStep++;
			}
			if (starStep == 2) {
				star2.GetComponent<Image> ().color = Color.Lerp (star2.GetComponent<Image> ().color, Color.white, starTimer);
			}
		} else if (score <= 99.0f && score > 0.0f) {
			if (starStep == 1) {
				star1.GetComponent<Image> ().color = Color.Lerp (star1.GetComponent<Image> ().color, Color.white, starTimer);
			}
			if (star1.GetComponent<Image> ().color == Color.white && starStep == 1) {
				starTimer = 0.0f;
				starStep++;
			}
			if (starStep == 2) {
				star2.GetComponent<Image> ().color = Color.Lerp (star2.GetComponent<Image> ().color, Color.white, starTimer);
			}
			if (star2.GetComponent<Image> ().color == Color.white && starStep == 2) {
				starTimer = 0.0f;
				starStep++;
			}
			if (starStep == 3) {
				star3.GetComponent<Image> ().color = Color.Lerp (star3.GetComponent<Image> ().color, Color.white, starTimer);
			}
			if (star3.GetComponent<Image> ().color == Color.white && starStep == 3) {
				starTimer = 0.0f;
				starStep++;
			}
		}
	}
}
