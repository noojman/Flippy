using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public GameObject parent;

	public GameObject player;

	public float DistanceToPlayer;

	private bool changeView;

	private float timer;

	public Camera myCamera;

	public int currentView;
	private float fov1;
    private float fov2;
    private float fov3;
    private float fov4;
    private float fov5;

    private bool initialTouch;
	private bool canTouch;

	private float cameraTimer;

	private Vector2 touchStart;
	private Vector3 cameraStartPos;

	private int liteMode;

	void Start () {
        fov1 = 8.0f;
        fov2 = 12.0f;
        fov3 = 16.0f;
        fov4 = 20.0f;
        fov5 = 24.0f;
        liteMode = PlayerPrefs.GetInt ("Lite Mode", 0);
		canTouch = true;
		changeView = false;
		initialTouch = true;
		cameraTimer = 0.0f;
		timer = 0.0f;
		currentView = PlayerPrefs.GetInt ("Zoom", 2);
		if (currentView == 1) {
			myCamera.fieldOfView = fov1;
		}
        else if (currentView == 2)
        {
			myCamera.fieldOfView = fov2;
		}
        else if (currentView == 3)
        {
			myCamera.fieldOfView = fov3;
        }
        else if (currentView == 4)
        {
            myCamera.fieldOfView = fov4;
        }
        else if (currentView == 5)
        {
            myCamera.fieldOfView = fov5;
        }
    }

	public void Zoom () {
		if (changeView == false) {
			changeView = true;
			timer = 0.0f;
		}
	}

	void Update() {
		if (player.GetComponent<PlayerBehavior> ().panMode == true) {
			if (Input.touches.Length > 0 && canTouch) {
				Touch t = Input.GetTouch (0);

				if (initialTouch) {
					GameObject.Find ("GamePanel").SendMessage ("Change");
					if (PlayerPrefs.GetInt("Vibrate") == 1) {
						Handheld.Vibrate ();
					}
					touchStart = t.position;
					initialTouch = false;
				}

				Vector2 touchCurrent = t.position;
				Vector2 touchDistance = new Vector2 (touchCurrent.x - touchStart.x, touchCurrent.y - touchStart.y);

				transform.position += transform.right * touchDistance.x / 1250.0f;
				transform.position += transform.up * touchDistance.y / 1250.0f;

				if (t.phase == TouchPhase.Ended) {
					GameObject.Find ("GamePanel").SendMessage ("Change");
					canTouch = false;
				}
			} else {
				cameraStartPos = parent.transform.position + new Vector3 (51.0f, 35.0f, 53.0f);
				cameraTimer += Time.deltaTime / 15.0f;
				transform.position = Vector3.Lerp(transform.position, cameraStartPos, cameraTimer);
				if (cameraTimer >= 0.1f) {
					player.GetComponent<PlayerBehavior> ().panMode = false;
					initialTouch = true;
					canTouch = true;
					cameraTimer = 0.0f;
				}
			}
		} else {
			if (changeView) {
				if (currentView == 5) {
					if (timer < 1.0f) {
						myCamera.fieldOfView = Mathf.Lerp (fov5, fov1, timer);
						timer += Time.deltaTime;
						if (timer >= 1.0f) {
							PlayerPrefs.SetInt ("Zoom", 1);
							currentView = 1;
							changeView = false;
						}
					}
				}
				if (currentView == 1) {
					if (timer < 1.0f) {
						myCamera.fieldOfView = Mathf.Lerp (fov1, fov2, timer);
						timer += Time.deltaTime * 2.0f;
						if (timer >= 1.0f) {
							PlayerPrefs.SetInt ("Zoom", 2);
							currentView = 2;
							changeView = false;
						}
					}
				}
				if (currentView == 2) {
					if (timer < 1.0f) {
						myCamera.fieldOfView = Mathf.Lerp (fov2, fov3, timer);
						timer += Time.deltaTime * 2.0f;
						if (timer >= 1.0f) {
							PlayerPrefs.SetInt ("Zoom", 3);
							currentView = 3;
							changeView = false;
						}
					}
				}
                if (currentView == 3)
                {
                    if (timer < 1.0f)
                    {
                        myCamera.fieldOfView = Mathf.Lerp(fov3, fov4, timer);
                        timer += Time.deltaTime * 2.0f;
                        if (timer >= 1.0f)
                        {
                            PlayerPrefs.SetInt("Zoom", 4);
                            currentView = 4;
                            changeView = false;
                        }
                    }
                }
                if (currentView == 4)
                {
                    if (timer < 1.0f)
                    {
                        myCamera.fieldOfView = Mathf.Lerp(fov4, fov5, timer);
                        timer += Time.deltaTime * 2.0f;
                        if (timer >= 1.0f)
                        {
                            PlayerPrefs.SetInt("Zoom", 5);
                            currentView = 5;
                            changeView = false;
                        }
                    }
                }
            }

			if (liteMode == 0) {
				RaycastHit[] hits;

				hits = Physics.RaycastAll (transform.position, transform.forward, DistanceToPlayer);
				foreach (RaycastHit hit in hits) {
					//Debug.Log("Found object to fade!");
					Renderer R = hit.collider.GetComponent<Renderer> ();
					if (R == null)
						continue; // no renderer attached? go to next hit
					
					AutoTransparent AT = R.GetComponent<AutoTransparent> ();
					if (AT == null) { // if no script is attached, attach one
						AT = R.gameObject.AddComponent<AutoTransparent> ();
						//Debug.Log("Adding script!");
					}
					AT.BeTransparent (); // get called every frame to reset the falloff
				}

                hits = Physics.RaycastAll(transform.position + new Vector3(0.0f, -0.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }

                hits = Physics.RaycastAll (transform.position + new Vector3 (0.0f, 0.5f, 0.0f), transform.forward, DistanceToPlayer);
				foreach (RaycastHit hit in hits) {
					//Debug.Log("Found object to fade!");
					Renderer R = hit.collider.GetComponent<Renderer> ();
					if (R == null)
						continue; // no renderer attached? go to next hit
					
					AutoTransparent AT = R.GetComponent<AutoTransparent> ();
					if (AT == null) { // if no script is attached, attach one
						AT = R.gameObject.AddComponent<AutoTransparent> ();
						//Debug.Log("Adding script!");
					}
					AT.BeTransparent (); // get called every frame to reset the falloff
				}

				hits = Physics.RaycastAll (transform.position + new Vector3 (0.0f, 1.0f, 0.0f), transform.forward, DistanceToPlayer);
				foreach (RaycastHit hit in hits) {
					//Debug.Log("Found object to fade!");
					Renderer R = hit.collider.GetComponent<Renderer> ();
					if (R == null)
						continue; // no renderer attached? go to next hit
					
					AutoTransparent AT = R.GetComponent<AutoTransparent> ();
					if (AT == null) { // if no script is attached, attach one
						AT = R.gameObject.AddComponent<AutoTransparent> ();
						//Debug.Log("Adding script!");
					}
					AT.BeTransparent (); // get called every frame to reset the falloff
				}

                hits = Physics.RaycastAll(transform.position + new Vector3(0.0f, 1.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }

                hits = Physics.RaycastAll(transform.position + new Vector3(0.5f, 0.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }

                hits = Physics.RaycastAll(transform.position + new Vector3(1.0f, 0.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }

                hits = Physics.RaycastAll(transform.position + new Vector3(-0.5f, 0.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }

                hits = Physics.RaycastAll(transform.position + new Vector3(-1.0f, 0.5f, 0.0f), transform.forward, DistanceToPlayer);
                foreach (RaycastHit hit in hits)
                {
                    //Debug.Log("Found object to fade!");
                    Renderer R = hit.collider.GetComponent<Renderer>();
                    if (R == null)
                        continue; // no renderer attached? go to next hit

                    AutoTransparent AT = R.GetComponent<AutoTransparent>();
                    if (AT == null)
                    { // if no script is attached, attach one
                        AT = R.gameObject.AddComponent<AutoTransparent>();
                        //Debug.Log("Adding script!");
                    }
                    AT.BeTransparent(); // get called every frame to reset the falloff
                }
            }
		}
	}
}