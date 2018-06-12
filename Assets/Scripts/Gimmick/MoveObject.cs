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
	Vector2 moveSpeed = new Vector2(.1f, .1f);
	[SerializeField]
	Vector2 move = new Vector2(.0f, .0f);

	public void Awake()
	{
		cashedTransform = this.transform;
	}

	public void Update()
	{
		MoveX();
		MoveY();
	}

	public void MoveX()
	{
		if(movePow.x <= .0f) return;

		if(move.x >= movePow.x) moveSpeed.x *= -1;
		else if(move.x <= -movePow.x) moveSpeed.x *= -1;

		move += new Vector2(moveSpeed.x, .0f);
		
		cashedTransform.position += new Vector3 (moveSpeed.x, .0f, .0f);
	}

	
	public void MoveY()
	{
		if(movePow.y <= .0f) return;

		if(move.y >= movePow.y) moveSpeed.y *= -1;
		else if(move.y <= -movePow.y) moveSpeed.y *= -1;

		move += new Vector2(.0f, moveSpeed.y);
		
		cashedTransform.position += new Vector3 ( .0f, moveSpeed.y, .0f);
	}

	private void DeathCheck(Collision2D other)
	{
		if(!deathFlg) return;

		if(other.gameObject.name == "Ball")
		{
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		DeathCheck(other);
	}
}
