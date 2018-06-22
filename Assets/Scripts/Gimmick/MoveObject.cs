using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : BaseGimmick {

	[SerializeField]
	Vector2 moveVec = new Vector2(1.0f, 1.0f);
	[SerializeField]
	Vector2 moveSpeed = new Vector2(.1f, .1f);
	[SerializeField]
	Vector2 move = new Vector2(.0f, .0f);

	public void Update()
	{
		MoveX();
		MoveY();
	}

	public void MoveX()
	{
		if(moveVec.x <= .0f) return;

		if(move.x >= moveVec.x) moveSpeed.x *= -1;
		else if(move.x <= -moveVec.x) moveSpeed.x *= -1;

		move += new Vector2(moveSpeed.x, .0f);
		
		cashedTransform.position += new Vector3 (moveSpeed.x, .0f, .0f);
	}

	
	public void MoveY()
	{
		if(moveVec.y <= .0f) return;

		if(move.y >= moveVec.y) moveSpeed.y *= -1;
		else if(move.y <= -moveVec.y) moveSpeed.y *= -1;

		move += new Vector2(.0f, moveSpeed.y);
		
		cashedTransform.position += new Vector3 ( .0f, moveSpeed.y, .0f);
	}
}
