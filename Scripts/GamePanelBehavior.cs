using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePanelBehavior : MonoBehaviour {

	public GameObject controller;

    Text levelText;

	private bool end;
	private bool move;
	private int currentPos;
	private float timer;

	private Vector2 startPos;
	
	void Start () {
        levelText = this.gameObject.GetComponentInChildren<Text>();
        levelText.text = "Lvl " + Application.loadedLevel;
        timer = 0.0f;
		startPos = this.GetComponent<RectTransform> ().anchoredPosition;
		currentPos = 0;
		move = true;
	}

	void Change () {
		if (currentPos == 0) {
			currentPos = 1;
		} else {
			currentPos = 0;
		}
		timer = 0.0f;
		move = true;
	}

	public void ChangePos () {
		if (currentPos == 0) {
			currentPos = 1;
		} else {
			currentPos = 0;
		}
		timer = 0.0f;
		move = true;
	}

	void Update () {
		if (controller.GetComponent<ControllerBehavior> ().finished && end == false) {
			ChangePos ();
			end = true;
		}
		if (move) {
			if (currentPos == 0) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (this.GetComponent<RectTransform> ().anchoredPosition, startPos + new Vector2 (0.0f, -51.0f), timer);
					timer += Time.deltaTime / 10.0f;
					if (timer >= 1.0f) {
						move = false;
					}
				}
			}
			if (currentPos == 1) {
				if (timer < 1.0f) {
					this.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (this.GetComponent<RectTransform> ().anchoredPosition, startPos, timer);
					timer += Time.deltaTime / 10.0f;
					if (timer >= 1.0f) {
						move = false;
					}
				}
			}
		}
	}
}