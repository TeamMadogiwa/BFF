using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	Transform cashedTransform;

	[SerializeField]
	bool deathFlg = false;

	[SerializeField]
	Vector2 movePow = new Vector2(1.0f, 1.0f);
	[SerializeField]
	Vector2 moveSpeed = new Vector2(1.0f, 1.0f);
	[SerializeField]
	Vector2 move = new Vector2(.0f, .0f);

	public void Awake()
	{
		cashedTransform = this.transform;
	}

	public void Update()
	{
		MoveX(movePow.x, move.x, moveSpeed.x);
	}

	public void MoveX(float px, float x, float speed)
	{
		if(px <= .0f) return;

		if(move.x <= -px) speed *= -1;
		else if(move.x >= px) speed *= -1;

		move += new Vector2(speed, .0f);
		
		cashedTransform.position += new Vector3 (speed, .0f, .0f);
		
	}
}
