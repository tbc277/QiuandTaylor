using UnityEngine;
using System.Collections;

public class tree_tear : MonoBehaviour {
	GameObject tree;

	public AudioClip au_8;

	private AudioSource source;

	void Start () 
	{
		tree = GameObject.Find ("tree");

		source = this.GetComponent<AudioSource> ();
	}
	

	void Update () 
	{
	   
	}

	void OnCollisionEnter2D(Collision2D col)
	{
//		if (col.gameObject.name == "Box4") 
//		{
//			Destroy (gameObject);
//			Debug.Log ("tearCollideBox4");
//		}

		if (col.gameObject.name == "Ball") 
		{
			tree.SendMessage ("isTearTouchwithBall");
			source.PlayOneShot (au_8, 0.8f);

		}
	}

}
