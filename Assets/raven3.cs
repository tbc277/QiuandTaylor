using UnityEngine;
using System.Collections;

public class raven3 : MonoBehaviour {
	SpriteRenderer sr_raven3;
	GameObject  ball;
	SpriteRenderer sr_ball;
	Color color1;

	GameObject eye1;
	GameObject eye2;

	SpriteRenderer sr_eye1;
	SpriteRenderer sr_eye2;

	TrailRenderer tr_ball;

	void Start () 
	{
	
		sr_raven3 = GetComponent<SpriteRenderer> ();
		sr_raven3.enabled = false;

		ball = GameObject.Find ("Ball");
		sr_ball = ball.GetComponent<SpriteRenderer> ();
		color1 = Color.white;

		eye1 = GameObject.Find ("eye1");
		eye2 = GameObject.Find ("eye2");
		sr_eye1 = eye1.GetComponent<SpriteRenderer> ();
		sr_eye2 = eye2.GetComponent<SpriteRenderer> ();

		tr_ball = ball.GetComponent<TrailRenderer> ();

	}

	void Update ()
	{
	
	}

	void appear ()
	{
		Debug.Log ("raven3 on the stage");
		sr_raven3.enabled = true;
		sr_ball.color = color1;

		sr_eye1.color = Color.black;
		sr_eye2.color = Color.black;

		//ball.FindProperty("m_Colors.m_Color[3]").colorValue = Color.white;
		//tr_ball.Colors.Color[3] = Color.white;
	}
}
