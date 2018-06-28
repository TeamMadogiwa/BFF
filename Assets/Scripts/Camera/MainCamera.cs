using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	Transform cashedTransform;

	[SerializeField]
	GameObject ball = null, wall = null;

	void Awake()
	{
			
		if(!ball)
		{
			ball = GameObject.FindGameObjectWithTag("Ball");
		}

		cashedTransform = this.transform;
		cashedTransform.position = new Vector3(.0f, ball.transform.position.y, -10.0f);
	}

	
	// Update is called once per frame
	void Update () {
		cashedTransform.position = new Vector3(.0f, ball.transform.position.y -2.0f, -10.0f);
	}
}
