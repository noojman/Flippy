using UnityEngine;
using System.Collections;

public class MenuStarsController : MonoBehaviour {

    public GameObject[] stars;

    private int[] items;

	void Start ()
    {
        items = new int[25];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = PlayerPrefs.GetInt("Item (" + i + ")", 1);
            if (items[i] == 0)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
	}

    public void Delete (string name)
    {
        PlayerPrefs.SetInt(name, 0);
    }
}
