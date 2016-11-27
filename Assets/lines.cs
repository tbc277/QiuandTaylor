using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lines : MonoBehaviour {
	Text t;
	float timeCounter;
	float currentTime;
	float currentTime2;

	bool linePointA;

	GameObject raven1;
	Vector3 v3Raven1;
	GameObject ball;
	bool reachRaven1;
	bool  eatenSun;

	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
		t.text = "Only this and nothing more. ";
		linePointA = false;

		raven1 = GameObject.Find ("raven1");
		v3Raven1 = raven1.transform.position;
		ball = GameObject.Find ("Ball");
		//Debug.Log (v3Raven1);

		reachRaven1 = false;
		eatenSun = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("blank text " + Mathf.Abs (currentTime2 - timeCounter));
		timeCounter += Time.deltaTime;
		//Debug.Log ("timenow: " + timeCounter);
	
		if (timeCounter > 4.5f && timeCounter < 5.1f && !linePointA) 
		{
			t.text = " ";
		}
		if (timeCounter > 5.1f && timeCounter < 8.0f && !linePointA) 
		{
			t.text = "You are looking for something.";
		}
		if (timeCounter > 8.0f && timeCounter < 8.5f && !linePointA) 
		{
			t.text = " ";
		}

		if (timeCounter > 8.5f && timeCounter < 12.5f && !linePointA) 
		{
			t.text = "Perhaps you are looking for someone. ";
		}
		if (timeCounter > 12.5f && timeCounter < 14.0f && !linePointA) 
		{
			t.text = "Something. ";
		}

		if (timeCounter > 14.0f && timeCounter < 14.8f && !linePointA) 
		{
			t.text = " ";
		}

		else if (timeCounter > 14.8f && timeCounter < 16.5f && !linePointA) 
		{
			t.text = "A name, a place, a feeling. ";
		}

		if ( Mathf.Abs(ball.transform.position.x - v3Raven1.x) <1.0f  && !linePointA)
		{
			t.text = "Instead, you may find the raven.";
			currentTime = timeCounter;
			reachRaven1 = true;
		}
		if ((timeCounter - currentTime) > 2.0f &&  reachRaven1 && !linePointA) 
		{
			t.text = "It will appear in the darkest places. You were not looking for it, but it is there all the same.";
		}

		if ((timeCounter - currentTime) > 5.5f &&  reachRaven1 && !linePointA) 
		{
			t.text = "Unsummoned and unbidden.";
		}

		if (Mathf.Abs (currentTime2 - timeCounter) > 4.5f  && eatenSun) 
		{
			Debug.Log ("blank text! ");
			t.text = " ";
		}

	}

	void lineWhenPointA()
	{
		linePointA = true;
		Debug.Log ("pointA");
		t.text = "Tread too far and the raven will swallow the light.";
	}

	void afterEatenSun()
	{
		t.text = "It will swallow what you are looking for, too. ";
		currentTime2 = timeCounter;
		eatenSun = true;
	}
}