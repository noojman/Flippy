using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuWallCubeControllerBehavior : MonoBehaviour {

    int currentStage;

    public GameObject stage1Cube1;
    public GameObject stage1Cube2;
    public GameObject stage2Cube1;
    public GameObject stage2Cube2;
    public GameObject stage3Cube1;
    public GameObject stage3Cube2;
    public GameObject stage4Cube1;
    public GameObject stage4Cube2;
    public GameObject stage5Cube1;
    public GameObject stage5Cube2;

    public GameObject unlockButton1;
    public GameObject unlockButton2;
    public GameObject unlockButton3;
    public GameObject unlockButton4;
    public GameObject unlockButton5;

    void Start ()
    {
        currentStage = PlayerPrefs.GetInt("Stage", 1);
        if (currentStage == 1)
        {
            PlayerPrefs.SetInt("Stage", 1);
        }
         else if (currentStage == 2)
        {
            PlayerPrefs.SetInt("Stage", 2);
            unlockButton1.GetComponent<Button>().interactable = false;
            stage1Cube1.transform.position = new Vector3(stage1Cube1.transform.position.x, 0.0f, stage1Cube1.transform.position.z);
            stage1Cube2.transform.position = new Vector3(stage1Cube2.transform.position.x, 0.0f, stage1Cube2.transform.position.z);
        }
        else if (currentStage == 3)
        {
            PlayerPrefs.SetInt("Stage", 3);
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            stage1Cube1.transform.position = new Vector3(stage1Cube1.transform.position.x, 0.0f, stage1Cube1.transform.position.z);
            stage1Cube2.transform.position = new Vector3(stage1Cube2.transform.position.x, 0.0f, stage1Cube2.transform.position.z);
            stage2Cube1.transform.position = new Vector3(stage2Cube1.transform.position.x, 0.0f, stage2Cube1.transform.position.z);
            stage2Cube2.transform.position = new Vector3(stage2Cube2.transform.position.x, 0.0f, stage2Cube2.transform.position.z);
        }
        else if (currentStage == 4)
        {
            PlayerPrefs.SetInt("Stage", 4);
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            stage1Cube1.transform.position = new Vector3(stage1Cube1.transform.position.x, 0.0f, stage1Cube1.transform.position.z);
            stage1Cube2.transform.position = new Vector3(stage1Cube2.transform.position.x, 0.0f, stage1Cube2.transform.position.z);
            stage2Cube1.transform.position = new Vector3(stage2Cube1.transform.position.x, 0.0f, stage2Cube1.transform.position.z);
            stage2Cube2.transform.position = new Vector3(stage2Cube2.transform.position.x, 0.0f, stage2Cube2.transform.position.z);
            stage3Cube1.transform.position = new Vector3(stage3Cube1.transform.position.x, 0.0f, stage3Cube1.transform.position.z);
            stage3Cube2.transform.position = new Vector3(stage3Cube2.transform.position.x, 0.0f, stage3Cube2.transform.position.z);
        }
        else if (currentStage == 5)
        {
            PlayerPrefs.SetInt("Stage", 5);
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            unlockButton4.GetComponent<Button>().interactable = false;
            stage1Cube1.transform.position = new Vector3(stage1Cube1.transform.position.x, 0.0f, stage1Cube1.transform.position.z);
            stage1Cube2.transform.position = new Vector3(stage1Cube2.transform.position.x, 0.0f, stage1Cube2.transform.position.z);
            stage2Cube1.transform.position = new Vector3(stage2Cube1.transform.position.x, 0.0f, stage2Cube1.transform.position.z);
            stage2Cube2.transform.position = new Vector3(stage2Cube2.transform.position.x, 0.0f, stage2Cube2.transform.position.z);
            stage3Cube1.transform.position = new Vector3(stage3Cube1.transform.position.x, 0.0f, stage3Cube1.transform.position.z);
            stage3Cube2.transform.position = new Vector3(stage3Cube2.transform.position.x, 0.0f, stage3Cube2.transform.position.z);
            stage4Cube1.transform.position = new Vector3(stage4Cube1.transform.position.x, 0.0f, stage4Cube1.transform.position.z);
            stage4Cube2.transform.position = new Vector3(stage4Cube2.transform.position.x, 0.0f, stage4Cube2.transform.position.z);
        }
        else if (currentStage == 6)
        {
            PlayerPrefs.SetInt("Stage", 6);
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            unlockButton4.GetComponent<Button>().interactable = false;
            unlockButton5.GetComponent<Button>().interactable = false;
            stage1Cube1.transform.position = new Vector3(stage1Cube1.transform.position.x, 0.0f, stage1Cube1.transform.position.z);
            stage1Cube2.transform.position = new Vector3(stage1Cube2.transform.position.x, 0.0f, stage1Cube2.transform.position.z);
            stage2Cube1.transform.position = new Vector3(stage2Cube1.transform.position.x, 0.0f, stage2Cube1.transform.position.z);
            stage2Cube2.transform.position = new Vector3(stage2Cube2.transform.position.x, 0.0f, stage2Cube2.transform.position.z);
            stage3Cube1.transform.position = new Vector3(stage3Cube1.transform.position.x, 0.0f, stage3Cube1.transform.position.z);
            stage3Cube2.transform.position = new Vector3(stage3Cube2.transform.position.x, 0.0f, stage3Cube2.transform.position.z);
            stage4Cube1.transform.position = new Vector3(stage4Cube1.transform.position.x, 0.0f, stage4Cube1.transform.position.z);
            stage4Cube2.transform.position = new Vector3(stage4Cube2.transform.position.x, 0.0f, stage4Cube2.transform.position.z);
            stage5Cube1.transform.position = new Vector3(stage5Cube1.transform.position.x, 0.0f, stage5Cube1.transform.position.z);
            stage5Cube2.transform.position = new Vector3(stage5Cube2.transform.position.x, 0.0f, stage5Cube2.transform.position.z);
        }
    }
    
    public void raise (int stage)
    {
        PlayerPrefs.SetInt("Stage", currentStage + 1);

        if (currentStage == 1)
        {
            unlockButton1.GetComponent<Button>().interactable = false;
            stage1Cube1.GetComponent<MenuWallCubeBehavior>().Move();
            stage1Cube2.GetComponent<MenuWallCubeBehavior>().Move();
        }
        else if (currentStage == 2)
        {
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            stage2Cube1.GetComponent<MenuWallCubeBehavior>().Move();
            stage2Cube2.GetComponent<MenuWallCubeBehavior>().Move();
        }
        else if (currentStage == 3)
        {
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            stage3Cube1.GetComponent<MenuWallCubeBehavior>().Move();
            stage3Cube2.GetComponent<MenuWallCubeBehavior>().Move();
        }
        else if (currentStage == 4)
        {
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            unlockButton4.GetComponent<Button>().interactable = false;
            stage4Cube1.GetComponent<MenuWallCubeBehavior>().Move();
            stage4Cube2.GetComponent<MenuWallCubeBehavior>().Move();
        }
        else if (currentStage == 5)
        {
            unlockButton1.GetComponent<Button>().interactable = false;
            unlockButton2.GetComponent<Button>().interactable = false;
            unlockButton3.GetComponent<Button>().interactable = false;
            unlockButton4.GetComponent<Button>().interactable = false;
            unlockButton5.GetComponent<Button>().interactable = false;
            stage5Cube1.GetComponent<MenuWallCubeBehavior>().Move();
            stage5Cube2.GetComponent<MenuWallCubeBehavior>().Move();
        }
    }
}
