using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBehavior : MonoBehaviour {
	
	public Scrollbar HealthBar;

	public float steps;

	public float health = 99.0f;

	public void Damage () {
		health -= 99.0f / steps;
        if (health < 0.0f)
        {
            health = 0.0f;
        }
		HealthBar.size = health / 99.0f;
	}

	public void Add () {
		health += 5 * 99.0f / steps;
		if (health > 99.0f) {
			health = 99.0f;
		}
		HealthBar.size = health / 99.0f;
	}

	public void Reset () {
		HealthBar.size = 1.0f;
	}
}
