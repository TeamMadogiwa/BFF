using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGimmick : MonoBehaviour {

	[SerializeField]
	protected bool deathFlg = false;

	[SerializeField]
	protected float scale = 1.0f;

	protected Transform cashedTransform;

	protected void Awake()
	{
		deathFlg = true;
		cashedTransform = this.transform;
		cashedTransform.localScale = new Vector3(scale, scale, scale);
	}

	protected void DeathCheck(Collision2D other)
	{
		if(!deathFlg) return;

		if(other.gameObject.tag == "Ball")
		{
			//ゲームオーバー処理(仮でスタート位置に)
			//other.transform.position = new Vector3(.0f, 3.0f, .0f);
			other.gameObject.GetComponent<Action>().Finished();
		}
	}

	protected void OnCollisionEnter2D(Collision2D other)
	{
		DeathCheck(other);
	}
}
