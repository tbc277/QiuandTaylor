using UnityEngine;
using System.Collections;

public class tree_tear : MonoBehaviour {
	GameObject tree;

	void Start () 
	{
		tree = GameObject.Find ("tree");
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
		}
	}

}
