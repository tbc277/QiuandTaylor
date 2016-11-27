using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	GameObject girl;
	SpriteRenderer sp_girl;

	GameObject raven2;
	SpriteRenderer sp_raven2;



	void Start () {

		girl = GameObject.Find ("girl");
		sp_girl = girl.GetComponent<SpriteRenderer> ();

		raven2 = GameObject.Find ("raven2");
		sp_raven2 = raven2.GetComponent<SpriteRenderer> ();

		//Debug.Log (girl);
		sp_girl.enabled = false;
		sp_raven2.enabled = false;


	}
	

	void Update () {
	
	}

	void OnCollisionEnter2D()
	{
		//Debug.Log ("something collide with the door");

		// the raven and a girl appear in the room
		sp_girl.enabled = true;
		sp_raven2.enabled = true;

		//destroy itself
		Destroy (gameObject);

	}
}
