using UnityEngine;
using System.Collections;

public class GameTutorialControllerBehavior : MonoBehaviour {

    public GameObject panel;
    public GameObject player;
    public GameObject controller;

    private Vector3 triggerLoc;

    private bool once;

    void Start()
    {
        once = true;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && once)
        {
            panel.GetComponent<TutorialPanelsBehavior>().ChangePos();
            once = false;
        }
        if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && once == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                panel.GetComponent<TutorialPanelsBehavior>().Close();
                PlayerPrefs.SetInt("First Time Running " + Application.loadedLevel, 0);
                once = true;
            }
        }
    }
}
