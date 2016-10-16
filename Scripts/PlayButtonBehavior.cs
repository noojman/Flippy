using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButtonBehavior : MonoBehaviour {

	public GameObject myCamera;
	
	void Update () {
		if (myCamera.GetComponent <MenuCameraBehavior> ().currentPos == 2) {
			this.GetComponentInChildren <Text> ().text = "[Back]";
		} else {
			this.GetComponentInChildren <Text> ().text = "[Play]";
		}
	}
}
