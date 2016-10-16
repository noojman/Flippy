using UnityEngine;
using System.Collections;

public class StarsPanelBehavior : MonoBehaviour {

    public GameObject controller;

    private bool set;
    private bool move;
    private int currentPos;
    private float timer;
    private Vector3 startPos;

    void Start()
    {
        timer = 0.0f;
        startPos = this.GetComponent<RectTransform>().localPosition;
        currentPos = 1;
        move = false;
    }

    public void ChangePos()
    {
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