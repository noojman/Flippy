using UnityEngine;
using System.Collections;

public class MovingBlockBehavior : MonoBehaviour {

	public GameObject player;

	public GameObject map;

	public float movementRatio; // prevents clash when block moves right as player moves
	public float waitTime; // how long the block waits before moving again
	public float distance; // distance that the block has to move
	public string direction; // direction that the block has to move

	private float timer1;
	private float timer2;
	private float timer3;
	private float timer4;

	private string playerTag;

	// Use this for initialization
	void Start () {
		this.GetComponent<Collider> ().enabled = false;
		timer1 = 0.0f;
		timer2 = 0.0f;
		timer3 = 0.0f;
		timer4 = 0.0f;
		playerTag = " ";
	}

	void OnTriggerEnter (Collider hit) {
		playerTag = hit.gameObject.tag;
		if (playerTag.Equals ("Player")) {
			player.GetComponent<PlayerBehavior> ().moveWithBlock = true;
		}
	}

	void OnTriggerExit (Collider hit) {
		player.GetComponent<PlayerBehavior> ().moveWithBlock = false;
		playerTag = "";
	}

	void Update () {
		Collider[] hitCollidersAt = Physics.OverlapSphere (transform.position, 0.5f);
		if (hitCollidersAt.Length > 0) {
			if (hitCollidersAt[0].gameObject.tag.Equals ("Player")) {
				playerTag = "Player";
				player.GetComponent<PlayerBehavior> ().moveWithBlock = true;
			}
			if (playerTag.Equals ("Player")) {
				if (timer1 < Mathf.Pow (distance, 2.0f)) {
					player.GetComponent<PlayerBehavior> ().canMove = false;
					player.GetComponent<PlayerBehavior> ().moveDirection = direction;
					player.GetComponent<PlayerBehavior> ().moveDistance = distance;
				} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
					player.GetComponent<PlayerBehavior> ().canMove = true;
					player.GetComponent<PlayerBehavior> ().moveDistance = 0.0f;
				} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
					player.GetComponent<PlayerBehavior> ().canMove = false;
					if (direction.Equals("forward")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "backward";
					} else if (direction.Equals("backward")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "forward";
					} else if (direction.Equals("left")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "right";
					} else if (direction.Equals("right")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "left";
					} else if (direction.Equals("up")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "down";
					} else if (direction.Equals("down")) {
						player.GetComponent<PlayerBehavior> ().moveDirection = "up";
					}
					player.GetComponent<PlayerBehavior> ().moveDistance = distance;
				} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
					player.GetComponent<PlayerBehavior> ().canMove = true;
					player.GetComponent<PlayerBehavior> ().moveDistance = 0.0f;
				}
			}
		}
	}

	void FixedUpdate () {
		if (direction == "forward") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.right * (-1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}

			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.right * (-1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else if (direction == "backward") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.right * (1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.right * (1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else if (direction == "left") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.forward * (-1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.forward * (-1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else if (direction == "right") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.forward * (1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.forward * (1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else if (direction == "up") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.up * (1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.up * (1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else if (direction == "down") {
			if (timer1 < Mathf.Pow (distance, 2.0f)) {
				transform.position += (transform.up * (-1.0f / distance));
				timer1 += 1.0f;
				if (timer1 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer1 == Mathf.Pow (distance, 2.0f) && timer2 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer2 += 1.0f;
				if (timer2 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else if (timer2 == waitTime && timer3 < Mathf.Pow (distance, 2.0f)) {
				transform.position -= (transform.up * (-1.0f / distance));
				timer3 += 1.0f;
				if (timer3 < (1.0f - movementRatio) * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				} else {
					this.GetComponent<Collider> ().enabled = true;
				}
			} else if (timer3 == Mathf.Pow (distance, 2.0f) && timer4 < waitTime) {
				if (map.GetComponent<MapBehavior> ().rotate == false) {
					transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
				}
				timer4 += 1.0f;
				if (timer4 > movementRatio * waitTime) {
					this.GetComponent<Collider> ().enabled = false;
				}
			} else {
				timer1 = 0.0f;
				timer2 = 0.0f;
				timer3 = 0.0f;
				timer4 = 0.0f;
			}
		} else {
			Debug.Log ("Error: block direction is off limits");
		}
	}
}
