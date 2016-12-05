using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	GameObject girl;
	SpriteRenderer sp_girl;

	GameObject raven2;
	SpriteRenderer sp_raven2;

	GameObject terre_1;
	SpriteRenderer sr_terre_1;

	GameObject terre_2;
	SpriteRenderer sr_terre_2;

	GameObject terre_3;
	SpriteRenderer sr_terre_3;

	void Start () {

		girl = GameObject.Find ("girl");
		sp_girl = girl.GetComponent<SpriteRenderer> ();

		raven2 = GameObject.Find ("raven2");
		sp_raven2 = raven2.GetComponent<SpriteRenderer> ();

		//Debug.Log (girl);
		sp_girl.enabled = false;
		sp_raven2.enabled = false;

		terre_1 = GameObject.Find ("terre_1");
		sr_terre_1 = terre_1.GetComponent<SpriteRenderer> ();

		terre_2 = GameObject.Find ("terre_2");
		sr_terre_2 = terre_2.GetComponent<SpriteRenderer> ();

		terre_3 = GameObject.Find ("terre_3");
		sr_terre_3 = terre_3.GetComponent<SpriteRenderer> ();


	}
	

	void Update () {
	
	}

	void OnCollisionEnter2D()
	{
		//Debug.Log ("something collide with the door");

		// the raven and a girl appear in the room
		sp_girl.enabled = true;
		sp_raven2.enabled = true;

		sr_terre_1.color = Color.black;
		sr_terre_2.color = Color.black;
		sr_terre_3.color = Color.black;

		//destroy itself
		Destroy (gameObject);

	}
}
