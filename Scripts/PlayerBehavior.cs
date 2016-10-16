using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Swipe {
	None,
	Up,
	Down,
	Left,
	Right,
	UpLeft,
	UpRight,
	DownLeft,
	DownRight
};

public class PlayerBehavior : MonoBehaviour {

	public GameObject touchBoundary;
	public GameObject healthBar;
	public GameObject mapController;
	public GameObject gameController;
	public GameObject puff;

    public AudioSource pop;
    public AudioSource bell;
    public AudioSource munch;
    public AudioSource trip;
    public AudioSource flapping;

    private string blockTag;

	private Animator anim;
	
	private bool inMove;
	private bool end;
    private bool tap;

	public bool panMode;
	public bool canMove;
	public bool moveWithBlock;
	public float moveDistance;
	public string moveDirection;

	private float counter;
	private float touchStart;
	private float touchEnd;

	private int direction;

	private Vector3 newPosition;

	private CharacterController controller;

	public float MinSwipeLength = 10;
	private Vector2 _firstPressPos;
	private Vector2 _secondPressPos;
	private Vector2 _currentSwipe;
	
	public Swipe SwipeDirection;

	void Start () {
        tap = false;
		end = true;
		transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		panMode = false;
		touchStart = 0.0f;
		touchEnd = 0.0f;
		canMove = true;
		controller = this.GetComponent<CharacterController> ();
		controller.detectCollisions = false;
		anim = this.GetComponentInChildren<Animator> ();
		direction = 0;
		blockTag = "";
		inMove = false;
		counter = 0.0f;
		moveWithBlock = false;
		moveDistance = 0.0f;
		moveDirection = " ";
	}

	void OnTriggerEnter (Collider hit) {
		blockTag = hit.gameObject.tag;
		//Debug.Log ("Standing on block: " + blockTag);
		if (!blockTag.Equals ("MovingBlock")) {
			moveWithBlock = false;
		}
	}
	
	void Move () {
		inMove = true;
		if (inMove) {
			newPosition = controller.transform.position + (transform.right * 2.0f);
		}
	}

	void FixedUpdate () {
		if (inMove) {			
			Vector3 moveDiff = newPosition - transform.position;
			Vector3 moveDir = moveDiff.normalized * 5.0f * Time.deltaTime;
			if (moveDir.sqrMagnitude < moveDiff.sqrMagnitude) {
				controller.Move (moveDir);
			} else {
				controller.Move (moveDiff);
			}
		}
		//Debug.Log (moveWithBlock);
		if (moveWithBlock) {
			if (counter < Mathf.Pow (moveDistance, 2.0f)) {
				if (moveDirection == "forward") {
					controller.transform.position += (mapController.transform.right * (-1.0f / moveDistance));
				} else if (moveDirection == "backward") {
					controller.transform.position += (mapController.transform.right * (1.0f / moveDistance));
				} else if (moveDirection == "left") {
					controller.transform.position += (mapController.transform.forward * (-1.0f / moveDistance));
				} else if (moveDirection == "right") {
					controller.transform.position += (mapController.transform.forward * (1.0f / moveDistance));
				} else if (moveDirection == "up") {
					controller.transform.position += (mapController.transform.up * (1.0f / moveDistance ));
				} else if (moveDirection == "down") {
					controller.transform.position += (mapController.transform.up * (-1.0f / moveDistance));
				}
				counter += 1.0f;
				if (counter == Mathf.Pow (moveDistance, 2.0f)) {
					counter = 0.0f;
					//transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), Mathf.Round (transform.position.z));
				}
			}
		} else {
			//Debug.Log("Resetting to zeroes.");
			counter = 0.0f;
			moveDistance = 0.0f;
		}
	}

	void Update () {
        if (inMove)
        {
            if (transform.position == newPosition)
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
                inMove = false;
            }
        }
        if (blockTag.Equals ("EndBlock")) {
            if (end)
            {
                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                {
                    bell.Play();
                }
                int tempStars = PlayerPrefs.GetInt("Stars");
                if (PlayerPrefs.GetInt("Block Number", 1) == gameController.GetComponent<ControllerBehavior> ().level)
                {
                    if (healthBar.GetComponent<Scrollbar>().size > 0.666f)
                    {
                        PlayerPrefs.SetInt("Stars", tempStars + 30);
                    }
                    else if (healthBar.GetComponent<Scrollbar>().size > 0.333f)
                    {
                        PlayerPrefs.SetInt("Stars", tempStars + 20);
                    }
                    else if (healthBar.GetComponent<HealthBehavior>().health > 0.0f)
                    {
                        PlayerPrefs.SetInt("Stars", tempStars + 10);
                    }
                } else
                {
                    float tempScore = PlayerPrefs.GetFloat("Level" + gameController.GetComponent<ControllerBehavior>().level + "Score");
                    if (tempScore > 0.333f)
                    {
                        PlayerPrefs.SetInt("Stars", tempStars + 10);
                    }
                    else if (tempScore > 0.0f)
                    {
                        PlayerPrefs.SetInt("Stars", tempStars + 20);
                    }
                }
                if (Application.loadedLevel == PlayerPrefs.GetInt("Block Number", 1))
                {
                    PlayerPrefs.SetInt("Block Number", Application.loadedLevel + 1);
                }
                end = false;
            }
			gameController.GetComponent<ControllerBehavior> ().finished = true;
			anim.Play ("Hop");
			transform.Rotate (transform.up * 2.0f);
		}
		Collider[] hitCollidersItems = Physics.OverlapSphere (transform.position + new Vector3 (0.0f, 1.6f, 0.0f), 0.7f);
		bool noItems = true;
		if (hitCollidersItems.Length > 0) {
			foreach (Collider item in hitCollidersItems) {
				if (item.gameObject.tag.Equals ("Item")) {
					noItems = false;
					anim.Play("Hop");
                    if (PlayerPrefs.GetInt("Audio", 1) == 1)
                    {
                        munch.Play();
                    }
					healthBar.SendMessage("Add");
					item.gameObject.SendMessage("Destroy");
				}
			}
		}
		if (hitCollidersItems.Length > 1 && noItems) {
            gameController.GetComponent<ControllerBehavior>().PlayExplode();
            puff.GetComponent<ParticleSystem> ().Play ();
			GameObject.Find ("GamePanel").SendMessage ("Change");
			GameObject.FindGameObjectWithTag("Fader").SendMessage("DeathRestart");
			this.gameObject.SetActive (false);
		}
		if (gameController.GetComponent<ControllerBehavior> ().inMenu == false && gameController.GetComponent<ControllerBehavior>().finished == false) {
			if (Input.GetKeyDown ("space")) {
				//Debug.Log("Moving: " + direction);
				if (inMove == false && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Hop") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Trip") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Bump")) {
					Collider[] hitCollidersHigh = Physics.OverlapSphere (transform.position + (transform.right * 2.0f) + new Vector3 (0.0f, 2.0f, 0.0f), 1.0f);
					Collider[] hitCollidersLow = Physics.OverlapSphere (transform.position + (transform.right * 2.0f) + new Vector3 (0.0f, 0.5f, 0.0f), 0.3f);
					if (blockTag.Equals ("RotateBlock") && hitCollidersLow.Length == 0) {
						mapController.GetComponent<MapBehavior> ().Rotate (direction, transform.position);
						anim.Play ("Hop");
						healthBar.SendMessage("Damage");
					} else if (!blockTag.Equals ("RotateBlock") && hitCollidersLow.Length == 0) {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            trip.Play();
                            flapping.Play();
                        }
						anim.Play ("Trip");
						healthBar.SendMessage("Damage");
					} else if (hitCollidersHigh.Length == 1 && !hitCollidersHigh[0].gameObject.tag.Equals("Item")) {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            pop.PlayDelayed(0.05f);
                            trip.PlayDelayed(0.25f);
                        }
						anim.Play ("Bump");
						healthBar.SendMessage("Damage");
					} else {
						foreach (Transform child in mapController.transform) {
							if (child.gameObject.tag.Equals ("MovingBlock")) {
								if (child.transform.position == (transform.position + (transform.right * 2.0f) + (transform.up * 2.0f))) {
									canMove = false;
								}
							}
						}
						if (moveDistance == 0.0f && canMove) {
                            if (PlayerPrefs.GetInt("Audio", 1) == 1)
                            {
                                pop.PlayDelayed(0.1f);
                            }
                            Move ();
							anim.Play ("Hop");
							healthBar.SendMessage("Damage");
						} else {
                            if (PlayerPrefs.GetInt("Audio", 1) == 1)
                            {
                                trip.Play();
                                flapping.Play();
                            }
							anim.Play ("Trip");
							healthBar.SendMessage("Damage");
							canMove = true;
						}
					}
				}
			}
			if (inMove == false && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Trip") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Bump")) {
				if (Input.GetKeyDown ("d")) {
					if (direction == 3) {
						direction = 0;
					} else {
						direction++;
					}
					transform.Rotate(new Vector3 (0.0f, -90.0f, 0.0f));
				}
				if (Input.GetKeyDown ("a")) {
					if (direction == 0) {
						direction = 3;
					} else {
						direction--;
					}
					transform.Rotate(new Vector3 (0.0f, 90.0f, 0.0f));
				}
			}
		}
		if (gameController.GetComponent<ControllerBehavior> ().inMenu == false && gameController.GetComponent<ControllerBehavior>().finished == false) {
			DetectSwipe ();
		}
	}
	
	class GetCardinalDirections {
		public static readonly Vector2 Up = new Vector2( 0, 1 );
		public static readonly Vector2 Down = new Vector2( 0, -1 );
		public static readonly Vector2 Right = new Vector2( 1, 0 );
		public static readonly Vector2 Left = new Vector2( -1, 0 );
		
		public static readonly Vector2 UpRight = new Vector2( 1, 1 );
		public static readonly Vector2 UpLeft = new Vector2( -1, 1 );
		public static readonly Vector2 DownRight = new Vector2( 1, -1 );
		public static readonly Vector2 DownLeft = new Vector2( -1, -1 );
	}

	public void DetectSwipe () {
		if (Input.touches.Length > 0 && panMode == false) {
			Touch t = Input.GetTouch(0);
			
			if (t.phase == TouchPhase.Began && t.position.y < touchBoundary.transform.position.y) {
				_firstPressPos = new Vector2(t.position.x, t.position.y);
				touchStart = Time.time;
			}

			if (t.phase == TouchPhase.Stationary && t.position.y < touchBoundary.transform.position.y) {
				touchEnd = Time.time - touchStart;
				if (touchEnd > 1.2f) {
					panMode = true;
                    tap = true;
				}
			}
			
			if (t.phase == TouchPhase.Ended && t.position.y < touchBoundary.transform.position.y) {
				_secondPressPos = new Vector2(t.position.x, t.position.y);
				_currentSwipe = new Vector3(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);
				
				// Make sure it was a legit swipe, not a tap
				if (_currentSwipe.magnitude < MinSwipeLength) {
					SwipeDirection = Swipe.None;
                    tap = true;
                    if (inMove == false && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Hop") && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Trip") && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Bump"))
                    {
                        Collider[] hitCollidersHigh = Physics.OverlapSphere(transform.position + (transform.right * 2.0f) + new Vector3(0.0f, 2.0f, 0.0f), 1.0f);
                        Collider[] hitCollidersLow = Physics.OverlapSphere(transform.position + (transform.right * 2.0f) + new Vector3(0.0f, 0.5f, 0.0f), 0.3f);
                        if (blockTag.Equals("RotateBlock") && hitCollidersLow.Length == 0)
                        {
                            mapController.GetComponent<MapBehavior>().Rotate(direction, transform.position);
                            anim.Play("Hop");
                            healthBar.SendMessage("Damage");
                        }
                        else if (!blockTag.Equals("RotateBlock") && hitCollidersLow.Length == 0)
                        {
                            if (PlayerPrefs.GetInt("Audio", 1) == 1)
                            {
                                trip.Play();
                                flapping.Play();
                            }
                            anim.Play("Trip");
                            healthBar.SendMessage("Damage");
                        }
                        else if (hitCollidersHigh.Length == 1 && !hitCollidersHigh[0].gameObject.tag.Equals("Item"))
                        {
                            if (PlayerPrefs.GetInt("Audio", 1) == 1)
                            {
                                pop.PlayDelayed(0.05f);
                                trip.PlayDelayed(0.25f);
                            }
                            anim.Play("Bump");
                            healthBar.SendMessage("Damage");
                        }
                        else
                        {
                            foreach (Transform child in mapController.transform)
                            {
                                if (child.gameObject.tag.Equals("MovingBlock"))
                                {
                                    if (child.transform.position == (transform.position + (transform.right * 2.0f) + (transform.up * 2.0f)))
                                    {
                                        canMove = false;
                                    }
                                }
                            }
                            if (moveDistance == 0.0f && canMove)
                            {
                                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                                {
                                    pop.PlayDelayed(0.1f);
                                }
                                Move();
                                anim.Play("Hop");
                                healthBar.SendMessage("Damage");
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                                {
                                    trip.Play();
                                    flapping.Play();
                                }
                                anim.Play("Trip");
                                healthBar.SendMessage("Damage");
                                canMove = true;
                            }
                        }
                    }
				}
				
				_currentSwipe.Normalize();
				
				// use dot product against 4 cardinal directions.
				// return if one of them is > 0.5f;
				
				print (_currentSwipe);
				
				//compare north
				if (tap == false && inMove == false && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Trip") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Bump")) {
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.Up ) > 0.906f) {
						return;
					}
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.Down ) > 0.906f) {
						return;
					}
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.Left ) > 0.906f) {
						if (direction == 0) {
							direction = 3;
						} else {
							direction--;
						}
						transform.Rotate(new Vector3 (0.0f, 90.0f, 0.0f));
						return;
					}
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.Right ) > 0.906f) {
						if (direction == 3) {
							direction = 0;
						} else {
							direction++;
						}
						transform.Rotate(new Vector3 (0.0f, -90.0f, 0.0f));
						return;
					}
					
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.UpRight ) >0.906f) {
						if (direction == 3) {
							direction = 0;
						} else {
							direction++;
						}
						transform.Rotate(new Vector3 (0.0f, -90.0f, 0.0f));
						return;
					}
					
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.UpLeft ) > 0.906f) {
						if (direction == 0) {
							direction = 3;
						} else {
							direction--;
						}
						transform.Rotate(new Vector3 (0.0f, 90.0f, 0.0f));
						return;
					}
					
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.DownLeft ) > 0.906f) {
						if (direction == 0) {
							direction = 3;
						} else {
							direction--;
						}
						transform.Rotate(new Vector3 (0.0f, 90.0f, 0.0f));
						return;
					}
					
					if (Vector2.Dot( _currentSwipe, GetCardinalDirections.DownRight ) > 0.906f) {
						if (direction == 3) {
							direction = 0;
						} else {
							direction++;
						}
						transform.Rotate(new Vector3 (0.0f, -90.0f, 0.0f));
						return;
					}
				}
                tap = false;
			}
		}
	}
}