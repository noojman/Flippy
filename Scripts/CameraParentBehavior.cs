using UnityEngine;
using System.Collections;

public class CameraParentBehavior : MonoBehaviour {

	public GameObject player;
	
	void Update () {
		transform.position = player.transform.position;
	}
}
