using UnityEngine;
using System.Collections;

public class MenuCameraBehavior : MonoBehaviour {

    public GameObject cameraParent;
	public GameObject player;
	public GameObject menuLights;
	
	private bool move;
	public int currentPos;
	private float timer;
	private float fov;
	
	private Quaternion startRot;
	private Vector3 startPos;
	
	private bool initialTouch;
	private bool canTouch;

    public bool follow;
	
	private float cameraTimer;
	
	private Vector2 touchStart;
	
	void Start () {
		canTouch = true;
		initialTouch = true;
		cameraTimer = 0.0f;
		timer = 0.0f;
		startRot = transform.rotation;
		startPos = transform.position;
		currentPos = 0;
		fov = Camera.main.fieldOfView;
		move = false;
        follow = false;
    }
	
	public void Change () {
        follow = false;
		if (currentPos == 1) {
			currentPos = 0;
			menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (0);
		} else {
			currentPos = 1;
			menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (-1);
		}
		timer = 0.0f;
		move = true;
	}

	public void GoToLevels () {
		if (currentPos == 2) {
            follow = false;
			currentPos = 0;
			menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (0);
		} else {
			int blockNumber = PlayerPrefs.GetInt("Block Number", 1);
            if (blockNumber > 80) {
				menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (5);
			} else if (blockNumber > 60) {
				menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (4);
			} else if (blockNumber > 40) {
				menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (3);
			} else if (blockNumber > 20) {
				menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (2);
			} else if (blockNumber > 0) {
				menuLights.GetComponent <MenuLightsBehavior> ().ChangeTo (1);
			}
			currentPos = 2;
		}
		timer = 0.0f;
		move = true;
	}

    void FixedUpdate() {
        if (move) {
            if (currentPos == 0) {
                if (timer < 1.0f) {
                    transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(transform.rotation.eulerAngles.x, startRot.eulerAngles.x, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.y, startRot.eulerAngles.y, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.z, startRot.eulerAngles.z, timer)));
                    transform.position = Vector3.Lerp(transform.position, startPos, timer);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov, timer);
                    timer += Time.deltaTime / 20.0f;
                }
            }
            if (currentPos == 1) {
                if (timer < 1.0f) {
                    transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(transform.rotation.eulerAngles.x, 23.0f, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.y, startRot.eulerAngles.y, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.z, startRot.eulerAngles.z, timer)));
                    transform.position = Vector3.Lerp(transform.position, startPos, timer);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov, timer);
                    timer += Time.deltaTime / 20.0f;
                }
            }
            if (currentPos == 2) {
                if (timer < 1.0f) {
                    transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(transform.rotation.eulerAngles.x, 40.0f, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.y, 200.0f, timer),
                                                                       Mathf.Lerp(transform.rotation.eulerAngles.z, 0.0f, timer)));
                    transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(20.5f, 53.0f, 57.0f), timer);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10.0f, timer);
                    timer += Time.deltaTime / 20.0f;
                    if (timer >= 0.1f) {
                        move = false;
                        follow = true;
                    }
                }
            }
        }
    }
     
    void Update ()
    {
        if (follow)
        {
            transform.parent = cameraParent.transform;
        }
	}
}
