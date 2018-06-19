using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

	[SerializeField]
	GameObject ball;
	Vector3 ballInit = new Vector3(.0f, 3.0f, .0f);

	[SerializeField]
	GameObject createLine;

	[SerializeField]
	private GameObject title;

	private bool isPlay = false;

	[SerializeField]
	private int nowLevel = 0;

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

		if( isPlay )
		{
			int Count = (int)(ball.GetComponent<Action>().moveY / 100.0f);
			if( nowLevel < Count )
			{
				Debug.Log("障害物生成");
				nowLevel++;
				GimmickManager.Instance.Create();
			}
		}
	}

	private void StartPrepare()
	{
		nowLevel = 0;
		isPlay = false;	
		ball.transform.position = ballInit;
		ball.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		title.SetActive(true);
		GimmickManager.Instance.GimmickDestroy();
		createLine.GetComponent<CreateLine>().Reset();
	}
	private void GameStart()
	{
		isPlay = true;
		ball.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
		title.SetActive(false);
		for (int i = 0; i < 2; i++)
		{
			GimmickManager.Instance.Create();
		}
	}
}
