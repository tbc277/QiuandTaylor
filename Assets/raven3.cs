using UnityEngine;
using System.Collections;

public class raven3 : MonoBehaviour {
	SpriteRenderer sr_raven3;

	void Start () 
	{
	
		sr_raven3 = GetComponent<SpriteRenderer> ();
		sr_raven3.enabled = false;
	}

	void Update () {
	
	}
}
