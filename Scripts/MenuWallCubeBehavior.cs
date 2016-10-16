using UnityEngine;
using System.Collections;

public class MenuWallCubeBehavior : MonoBehaviour {

	public void Move ()
    {
        this.GetComponent<ParticleSystem>().Play();
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
	}
}
