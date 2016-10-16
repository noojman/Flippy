using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class MenuPlayerBehavior : MonoBehaviour {

    public GameObject touchBoundary;
    public GameObject touchBoundary2;
    public GameObject myCamera;
	public GameObject mapController;
    public GameObject menuController;
	public GameObject puff;
	public GameObject fader;
	public GameObject number;
	public GameObject detailsCanvas;
	public GameObject lights;
    public GameObject menuStars;

    public AudioSource pop;
    public AudioSource munch;
    public AudioSource trip;
    public AudioSource flapping;
    public AudioSource bell;

    private string blockTag;
	
	private Animator anim;
	
	private bool inMove;
	private bool end;
    private bool tap;
	
	private float counter;
	private float touchStart;
	private float touchEnd;
	
	private int direction;

	public int blockNumber;
	
	private Vector3 newPosition;
	
	private CharacterController controller;
	
	public float MinSwipeLength = 10;
	private Vector2 _firstPressPos;
	private Vector2 _secondPressPos;
	private Vector2 _currentSwipe;
	
	public Swipe SwipeDirection;

    void Start() {
        tap = false;
        end = false;
        blockNumber = PlayerPrefs.GetInt("Block Number", 1);
        if (blockNumber > 20 && PlayerPrefs.GetInt("Stage", 1) == 1)
        {
            transform.position = GameObject.Find("LevelCube (20)").transform.position;
        }
        else if (blockNumber > 40 && PlayerPrefs.GetInt("Stage", 1) == 2)
        {
            transform.position = GameObject.Find("LevelCube (40)").transform.position;
        }
        else if (blockNumber > 60 && PlayerPrefs.GetInt("Stage", 1) == 3)
        {
            transform.position = GameObject.Find("LevelCube (60)").transform.position;
        }
        else if (blockNumber > 80 && PlayerPrefs.GetInt("Stage", 1) == 4)
        {
            transform.position = GameObject.Find("LevelCube (80)").transform.position;
        }
        else if (blockNumber > 100 && PlayerPrefs.GetInt("Stage", 1) == 5)
        {
            transform.position = GameObject.Find("LevelCube (100)").transform.position;
        } else
        {
            transform.position = GameObject.Find("LevelCube (" + blockNumber + ")").transform.position;
        }
        touchStart = 0.0f;
        touchEnd = 0.0f;
        controller = this.GetComponent<CharacterController>();
        controller.detectCollisions = false;
        anim = this.GetComponentInChildren<Animator>();
        direction = 0;
        blockTag = "";
        inMove = false;
        counter = 0.0f;
        
        Analytics.CustomEvent("gameStart", new Dictionary<string, object>
        {
            { "currentLevel", blockNumber },
            { "currentStage", PlayerPrefs.GetInt("Stage") },
            { "stars", PlayerPrefs.GetInt("Stars") }
    });
    }
	
	void OnTriggerEnter (Collider hit) {
		blockTag = hit.gameObject.tag;
		if (blockTag.Equals ("PlainBlock")) {
			detailsCanvas.GetComponent <Canvas> ().enabled = true;
			blockNumber = int.Parse (hit.GetComponentInChildren<Text> ().text);
			number.GetComponent <Text> ().text = "" + blockNumber;
			detailsCanvas.GetComponent <DetailsCanvasBehavior> ().Reset ();
			if (myCamera.GetComponent <MenuCameraBehavior> ().currentPos == 2) {
				if (blockNumber == 1 || blockNumber == 20) {
					lights.GetComponent <MenuLightsBehavior> ().ChangeTo (1);
				} else if (blockNumber == 36 || blockNumber == 40) {
					lights.GetComponent <MenuLightsBehavior> ().ChangeTo (2);
				} else if (blockNumber == 45 || blockNumber == 41) {
					lights.GetComponent <MenuLightsBehavior> ().ChangeTo (3);
				} else if (blockNumber == 61 || blockNumber == 80) {
					lights.GetComponent <MenuLightsBehavior> ().ChangeTo (4);
				} else if (blockNumber == 100 || blockNumber == 85) {
					lights.GetComponent <MenuLightsBehavior> ().ChangeTo (5);
				}
			}
		} else if (blockTag.Equals ("EndBlock")) {
			lights.GetComponent <MenuLightsBehavior> ().ChangeTo (-2);
			detailsCanvas.GetComponent <Canvas> ().enabled = false;
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
        if (end) {
			anim.Play ("Hop");
			transform.Rotate (transform.up * 2.0f);
		}
		Collider[] hitCollidersItems = Physics.OverlapSphere (transform.position + new Vector3 (0.0f, 1.6f, 0.0f), 0.7f);
		if (hitCollidersItems.Length > 0) {
			foreach (Collider item in hitCollidersItems) {
				if (item.gameObject.tag.Equals ("Item")) {
					anim.Play("Hop");
                    if (PlayerPrefs.GetInt("Audio", 1) == 1)
                    {
                        munch.Play();
                    }
                    menuStars.GetComponent<MenuStarsController>().Delete(item.gameObject.name);
					Destroy(item.gameObject);
                    PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 10);
				}
			}
		}
		if (myCamera.GetComponent <MenuCameraBehavior> ().follow && end == false && menuController.GetComponent<MenuControllerBehavior>().inMenu == false) {
			if (Input.GetKeyDown ("space")) {
				//Debug.Log("Moving: " + direction);
				if (inMove == false && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Hop") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Trip") && !anim.GetCurrentAnimatorStateInfo (0).IsTag ("Bump")) {
					Collider[] hitCollidersHigh = Physics.OverlapSphere (transform.position + (transform.right * 2.0f) + new Vector3 (0.0f, 2.0f, 0.0f), 1.0f);
					Collider[] hitCollidersLow = Physics.OverlapSphere (transform.position + (transform.right * 2.0f) + new Vector3 (0.0f, 0.5f, 0.0f), 0.3f);
					if (blockTag.Equals ("RotateBlock") && hitCollidersLow.Length == 0) {
						mapController.GetComponent<MapBehavior> ().Rotate (direction, transform.position);
						anim.Play ("Hop");
                    }
                    else if (!blockTag.Equals("RotateBlock") && hitCollidersLow.Length == 0)
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            trip.Play();
                            flapping.Play();
                        }
                        anim.Play("Trip");
                    }
                    else if (hitCollidersHigh.Length == 1 && !hitCollidersHigh[0].gameObject.tag.Equals("Item"))
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            pop.PlayDelayed(0.05f);
                            trip.PlayDelayed(0.25f);
                        }
                        anim.Play("Bump");
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            pop.PlayDelayed(0.1f);
                        }
                        Move ();
                        anim.Play ("Hop");
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
		if (myCamera.GetComponent<MenuCameraBehavior> ().follow && end == false && menuController.GetComponent<MenuControllerBehavior>().inMenu == false) {
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
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);
			
			if (t.phase == TouchPhase.Began && t.position.y > touchBoundary.transform.position.y && t.position.y < touchBoundary2.transform.position.y) {
				_firstPressPos = new Vector2(t.position.x, t.position.y);
				touchStart = Time.time;
			}
			
			if (t.phase == TouchPhase.Stationary && t.position.y > touchBoundary.transform.position.y && t.position.y < touchBoundary2.transform.position.y) {
				touchEnd = Time.time - touchStart;
				if (touchEnd > 1.5f) {
                    tap = true;
					if (PlayerPrefs.GetInt ("Block Number", 1) < blockNumber) {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            trip.Play();
                            flapping.Play();
                        }
                        anim.Play ("Trip");
					} else {
                        if (PlayerPrefs.GetInt("Audio", 1) == 1)
                        {
                            bell.Play();
                        }
                        end = true;
                        fader.GetComponent<FaderBehavior>().GoToLevel(blockNumber);
                    }
				}
			}

            Ray cursorRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (t.phase == TouchPhase.Ended && t.position.y > touchBoundary.transform.position.y && t.position.y < touchBoundary2.transform.position.y)
            {
                if (this.gameObject.GetComponent<BoxCollider>().Raycast(cursorRay, out hit, 1000.0f))
                {
                    if (PlayerPrefs.GetInt("Audio", 1) == 1)
                    {
                        trip.Play();
                    }
                    anim.Play("Hop");
                }
                else
                {
                    _secondPressPos = new Vector2(t.position.x, t.position.y);
                    _currentSwipe = new Vector3(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);

                    // Make sure it was a legit swipe, not a tap
                    if (_currentSwipe.magnitude < MinSwipeLength)
                    {
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
                            }
                            else if (!blockTag.Equals("RotateBlock") && hitCollidersLow.Length == 0)
                            {
                                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                                {
                                    trip.Play();
                                    flapping.Play();
                                }
                                anim.Play("Trip");
                            }
                            else if (hitCollidersHigh.Length == 1 && !hitCollidersHigh[0].gameObject.tag.Equals("Item"))
                            {
                                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                                {
                                    pop.PlayDelayed(0.05f);
                                    trip.PlayDelayed(0.25f);
                                }
                                anim.Play("Bump");
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("Audio", 1) == 1)
                                {
                                    pop.PlayDelayed(0.1f);
                                }
                                Move();
                                anim.Play("Hop");
                            }
                        }
                    }

                    _currentSwipe.Normalize();

                    // use dot product against 4 cardinal directions.
                    // return if one of them is > 0.5f;

                    print(_currentSwipe);

                    //compare north
                    if (tap == false && inMove == false && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Trip") && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Bump"))
                    {
                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Up) > 0.906f)
                        {
                            return;
                        }
                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Down) > 0.906f)
                        {
                            return;
                        }
                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Left) > 0.906f)
                        {
                            if (direction == 0)
                            {
                                direction = 3;
                            }
                            else
                            {
                                direction--;
                            }
                            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                            return;
                        }
                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.Right) > 0.906f)
                        {
                            if (direction == 3)
                            {
                                direction = 0;
                            }
                            else
                            {
                                direction++;
                            }
                            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
                            return;
                        }

                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.UpRight) > 0.906f)
                        {
                            if (direction == 3)
                            {
                                direction = 0;
                            }
                            else
                            {
                                direction++;
                            }
                            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
                            return;
                        }

                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.UpLeft) > 0.906f)
                        {
                            if (direction == 0)
                            {
                                direction = 3;
                            }
                            else
                            {
                                direction--;
                            }
                            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                            return;
                        }

                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.DownLeft) > 0.906f)
                        {
                            if (direction == 0)
                            {
                                direction = 3;
                            }
                            else
                            {
                                direction--;
                            }
                            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                            return;
                        }

                        if (Vector2.Dot(_currentSwipe, GetCardinalDirections.DownRight) > 0.906f)
                        {
                            if (direction == 3)
                            {
                                direction = 0;
                            }
                            else
                            {
                                direction++;
                            }
                            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
                            return;
                        }
                    }
                    tap = false;
                }
			}
		}
	}
}
