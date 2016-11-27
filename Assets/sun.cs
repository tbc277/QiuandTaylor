using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {

	GameObject raven;
	GameObject hill1;
	GameObject hill2;
	GameObject hill3;

	GameObject tear1;
	GameObject tear2;
	SpriteRenderer sr_sun;

	GameObject lines;

	void Start () {

		raven = GameObject.Find ("raven1");
		hill1 = GameObject.Find ("hill1");
		hill2 = GameObject.Find ("hill2");
		hill3 = GameObject.Find ("hill3");

		tear1 = GameObject.Find ("tear1");
		tear2 = GameObject.Find ("tear2");

		sr_sun = GetComponent<SpriteRenderer> ();

		lines = GameObject.Find ("lines");
	}

	void Update () {
	
	}

	void eaten() // destroy itself
	{
		Destroy (raven);
		Destroy (hill1);
		Destroy (hill2);
		Destroy (hill3);

		tear1.SendMessage ("tearGuide1");
		tear2.SendMessage ("tearGuide2");

		lines.SendMessage ("afterEatenSun");

		sr_sun.enabled = false;
		//Destroy (gameObject);

	}
}
