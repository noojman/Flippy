using UnityEngine;
using System.Collections;

public class ParticlesBehavior : MonoBehaviour {

	void Update () {
		if (PlayerPrefs.GetInt ("Lite Mode") == 0) {
			this.GetComponent <ParticleSystem> ().Play ();
		} else {
			this.GetComponent <ParticleSystem> ().Stop ();
			this.GetComponent <ParticleSystem> ().Clear ();
		}
	}
}
