using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

	[SerializeField]
	GameObject ball;
	Vector3 ballInit = new Vector3(.0f, 3.0f, .0f);


	GimmickManager gManager;

	// Use this for initialization
	public void Awake()
	{
		ball.transform.position = ballInit;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			ball.transform.position = ballInit;
		}
	}
}
