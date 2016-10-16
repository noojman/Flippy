using UnityEngine;
using System.Collections;

public class TutorialControllerBehavior : MonoBehaviour {

    public GameObject myCamera;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    private int stage;

    private bool once;
    private bool next;
    private bool check;

    void Start ()
    {
        if (PlayerPrefs.GetInt("Block Number", 1) != 1)
        {
            PlayerPrefs.SetInt("First Time Running", 0);
        }
        stage = 1;
        once = false;
        next = true;
        check = true;
    }

    public void PlayClicked ()
    {
        if (check)
        {
            once = true;
            check = false;
            stage = 1;
        } else
        {
            panel1.GetComponent<TutorialPanelsBehavior>().Close();
            panel2.GetComponent<TutorialPanelsBehavior>().Close();
            panel3.GetComponent<TutorialPanelsBehavior>().Close();
            panel4.GetComponent<TutorialPanelsBehavior>().Close();
            stage = 1;
            check = true;
        }
    }

    void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            next = true;
        }

        if (PlayerPrefs.GetInt("First Time Running", 1) == 1 && myCamera.GetComponent<MenuCameraBehavior>().currentPos == 2)
        {
            if (stage == 1)
            {
                if (once)
                {
                    Debug.Log("Run 1");
                    panel1.GetComponent<TutorialPanelsBehavior>().ChangePos();
                    once = false;
                }
                if (Input.GetMouseButtonDown(0) && next)
                {
                    panel1.GetComponent<TutorialPanelsBehavior>().Close();
                    once = true;
                    stage++;
                    next = false;
                }
            }

            if (stage == 2)
            {
                if (once)
                {
                    panel2.GetComponent<TutorialPanelsBehavior>().ChangePos();
                    once = false;
                }
                if (Input.GetMouseButtonDown(0) && next)
                {
                    panel2.GetComponent<TutorialPanelsBehavior>().Close();
                    once = true;
                    stage++;
                    next = false;
                }
            }

            if (stage == 3)
            {
                if (once)
                {
                    panel3.GetComponent<TutorialPanelsBehavior>().ChangePos();
                    once = false;
                }
                if (Input.GetMouseButtonDown(0) && next)
                {
                    panel3.GetComponent<TutorialPanelsBehavior>().Close();
                    once = true;
                    stage++;
                    next = false;
                }
            }

            if (stage == 4)
            {
                if (once)
                {
                    panel4.GetComponent<TutorialPanelsBehavior>().ChangePos();
                    once = false;
                }
                if (Input.GetMouseButtonDown(0) && next)
                {
                    panel4.GetComponent<TutorialPanelsBehavior>().Close();
                    once = true;
                    stage++;
                    next = false;
                    PlayerPrefs.SetInt("First Time Running", 0);
                }
            }
        }
    }
}
