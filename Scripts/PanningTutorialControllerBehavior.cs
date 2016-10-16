using UnityEngine;
using System.Collections;

public class PanningTutorialControllerBehavior : MonoBehaviour {

    public GameObject panel1;
    public GameObject panel2;
    public GameObject player;
    public GameObject controller;

    private Vector3 triggerLoc;

    private int stage;

    private bool once;

    void Start()
    {
        stage = 1;
        once = true;
    }

    void Update()
    {
        if (stage == 1)
        {
            if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && once)
            {
                panel1.GetComponent<TutorialPanelsBehavior>().ChangePos();
                once = false;
            }
            if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && once == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    panel1.GetComponent<TutorialPanelsBehavior>().Close();
                    once = true;
                    stage++;
                }
            }
        }
        else if (stage == 2)
        {
            if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && player.GetComponent<PlayerBehavior>().panMode == true && once)
            {
                panel2.GetComponent<TutorialPanelsBehavior>().ChangePos();
                once = false;
            }
            else if (PlayerPrefs.GetInt("First Time Running " + Application.loadedLevel, 1) == 1 && Input.GetMouseButtonUp(0) && once == false)
            {
                panel2.GetComponent<TutorialPanelsBehavior>().Close();
                PlayerPrefs.SetInt("First Time Running " + Application.loadedLevel, 0);
            }
        }
    }
}
