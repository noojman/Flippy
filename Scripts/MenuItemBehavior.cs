using UnityEngine;
using System.Collections;

public class MenuItemBehavior : MonoBehaviour {

    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0, 360), 0.0f));
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, 1.5f, 0.0f));
    }
}
