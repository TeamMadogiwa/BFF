using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

	[SerializeField]
	GameObject ball;
	Vector3 ballInit = new Vector3(.0f, 3.0f, .0f);

	[SerializeField]
	private GameObject title;

	private bool isPlay = false;

	// Use this for initialization
	void Awake()
	{
		ball.GetComponent<Action>().ReturnStart = StartPrepare;
		StartPrepare();
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if( !isPlay )
				GameStart();
		}
	}

	private void StartPrepare()
	{
		isPlay = false;	
		ball.transform.position = ballInit;
		ball.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		title.SetActive(true);
	}
	private void GameStart()
	{
		isPlay = true;
		ball.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
		title.SetActive(false);
		for (int i = 0; i < 20; i++)
		{
			GimmickManager.Instance.Create();
		}
	}
}
