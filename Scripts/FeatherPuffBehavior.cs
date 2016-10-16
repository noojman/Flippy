using UnityEngine;
using System.Collections;

public class FeatherPuffBehavior : MonoBehaviour {
	
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + new Vector3(0.0f, 1.5f, 0.0f);
	}
}
