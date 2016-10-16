using UnityEngine;
using System.Collections;

public class ItemBehavior : MonoBehaviour {

	void Start () {
        if (transform.rotation.eulerAngles.x == 0.0f || transform.rotation.eulerAngles.x == 180.0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Random.Range(0.0f, 360.0f)));
        }
        else if (transform.rotation.eulerAngles.x == 90.0f || transform.rotation.eulerAngles.x == 270.0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, Random.Range(0.0f, 360.0f), transform.rotation.eulerAngles.z));
        }
    }

    void FixedUpdate () {
        transform.Rotate(new Vector3 (0.0f, 0.0f, 1.5f));
    }

	public void Destroy () {
		this.gameObject.SetActive (false);
	}
}
