using UnityEngine;
using System.Collections;

public class CmeraFollow : MonoBehaviour {
	public GameObject player;
	public float followSpeed;

	public Vector2 bias;
	// Use this for initialization
	float cam_y;

	void Start () {
		
	}



	void FixedUpdate () {
		FollowPlayer ();
	}

	void FollowPlayer()
	{
		transform.position = Vector3.Lerp (transform.position, new Vector3(player.transform.position.x+bias.x, 
																			this.transform.position.y, transform.position.z), 
																			Time.deltaTime * followSpeed);
	}
}
