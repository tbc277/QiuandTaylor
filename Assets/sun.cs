using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {

	GameObject raven;
	GameObject hill1;
	GameObject hill2;
	GameObject hill3;

	void Start () {

		raven = GameObject.Find ("raven1");
		hill1 = GameObject.Find ("hill1");
		hill2 = GameObject.Find ("hill2");
		hill3 = GameObject.Find ("hill3");
	}

	void Update () {
	
	}

	void eaten() // destroy itself
	{
		Destroy (raven);
		Destroy (hill1);
		Destroy (hill2);
		Destroy (hill3);
		Destroy (gameObject);

	}
}
