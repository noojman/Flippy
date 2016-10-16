using UnityEngine;
using System.Collections;

public class MapBehavior : MonoBehaviour {

    public AudioSource swoosh;

	public  Vector3 position;

	private int rotation;

	public bool rotate;
	private bool first;

	private Vector3 axis;

	private Quaternion oldRotation;
	private Quaternion newRotation;

	private float step;
	
	// Use this for initialization
	void Start () {
		first = false;
		rotate = false;
		float step = 0.0f;
	}

	void Awake () {
		first = false;
		rotate = false;
		float step = 0.0f;
	}

	void Update () {
		if (first == true) {
			if (rotation == 2) {
				axis = new Vector3 (0.0f, 0.0f, -1.0f);
			} else if (rotation == 3) {
				axis = Vector3.right;
			} else if (rotation == 0) {
				axis = new Vector3 (0.0f, 0.0f, 1.0f);
			} else {
				axis = Vector3.left;
			}
			first = false;
		}
	}

	void FixedUpdate () {
		if (rotate == true) {
			transform.RotateAround (position, axis, 4.5f);

			step += 4.5f;

			if (step == 90.0f) {
				rotate = false;
				step = 0.0f;
			}
		}
	}

	public  void Rotate (int rot, Vector3 pos) {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            swoosh.Play();
        }
		first = true;
		rotate = true;
		rotation = rot;
		position = pos + new Vector3 (0.0f, 0.0f, 0.0f);
	}
}
