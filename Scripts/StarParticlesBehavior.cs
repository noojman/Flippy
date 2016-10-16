using UnityEngine;
using System.Collections;

public class StarParticlesBehavior : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	public void StartParticles () {
		star1.GetComponent <ParticleSystem> ().Play ();
		star2.GetComponent <ParticleSystem> ().Play ();
		star3.GetComponent <ParticleSystem> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
