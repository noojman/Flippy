using UnityEngine;
using System.Collections;

public class PausePanelBehavior : MonoBehaviour {

	public GameObject controller;
	
	private bool move;
	private int currentPos;
	private float timer;
	private Vector3 startPos;
	
	void Start () {
		timer = 0.0f;
		startPos = this.GetComponent<RectTransform> ().localPosition;
		currentPos = 1;
		move = false;
	}
	
	public void ChangePos () {
		if (currentPos == 0) {
			currentPos = 1;
			controller.GetComponent<ControllerBehavior> ().inMenu = false;
		} else {
			currentPos = 0;
			controller.GetComponent<ControllerBehavior> ().inMenu = true;
		}
		timer = 0.0f;
		move = true;
	}
	
	void Update () {
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