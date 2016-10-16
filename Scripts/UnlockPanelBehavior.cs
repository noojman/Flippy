using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnlockPanelBehavior : MonoBehaviour {

    public AudioSource unlock;

    public GameObject controller;
    public GameObject starsPanel;
    public GameObject wallCubes;

    private bool set;
    private bool move;
    private int currentPos;
    private int stage;
    private float timer;
    private Vector3 startPos;

    void Start()
    {
        set = false;
        timer = 0.0f;
        startPos = this.GetComponent<RectTransform>().localPosition;
        currentPos = 1;
        move = false;
    }

    public void ChangePos(int stg)
    {
        if (stg != 0)
        {
            stage = stg;
        }
        if (currentPos == 0)
        {
            currentPos = 1;
        }
        else
        {
            currentPos = 0;
        }
        timer = 0.0f;
        move = true;
    }

    public void TryUnlock ()
    {
        int stars = PlayerPrefs.GetInt("Stars");
        if (stars >= 500)
        {
            wallCubes.GetComponent<MenuWallCubeControllerBehavior>().raise(stage);
            PlayerPrefs.SetInt("Stars", stars - 500);
            if (PlayerPrefs.GetInt("Audio", 1) == 1)
            {
                unlock.Play();
            }
        }
        else
        {
            starsPanel.GetComponent<StarsPanelBehavior>().ChangePos();
        }
    }

    void Update()
    {
        if (currentPos == 0)
        {
            if (Input.GetMouseButton(0) && set
                && !RectTransformUtility.RectangleContainsScreenPoint(
                    this.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null))
            {
                currentPos = 1;
                timer = 0.0f;
                move = true;
                set = false;
            }
        }

        if (move)
        {
            if (currentPos == 0)
            {
                if (timer < 1.0f)
                {
                    controller.GetComponent<MenuControllerBehavior>().inMenu = true;
                    this.GetComponent<RectTransform>().localPosition = Vector3.Lerp(this.GetComponent<RectTransform>().localPosition, new Vector3(0.0f, -70.0f), timer);
                    timer += Time.deltaTime / 3.0f;
                    if (timer >= 0.1f)
                    {
                        set = true;
                    }
                    if (timer >= 1.0f)
                    {
                        move = false;
                    }
                }
            }
            if (currentPos == 1)
            {
                if (timer < 1.0f)
                {
                    this.GetComponent<RectTransform>().localPosition = Vector3.Lerp(this.GetComponent<RectTransform>().localPosition, startPos, timer);
                    timer += Time.deltaTime / 3.0f;
                    if (timer >= 0.1f)
                    {
                        controller.GetComponent<MenuControllerBehavior>().inMenu = false;
                    }
                    if (timer >= 1.0f)
                    {
                        move = false;
                    }
                }
            }
        }
    }
}