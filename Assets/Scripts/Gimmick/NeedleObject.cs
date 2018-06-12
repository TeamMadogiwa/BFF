using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleObject : MonoBehaviour {

	Transform cashedTransform;

	[SerializeField]
	float scale = 1.0f;

	void Awake()
	{
		cashedTransform = this.transform;
		cashedTransform.transform.localScale = new Vector3(scale, scale, scale);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "Ball")
		{
			Destroy(other.gameObject);
		}
	}
}
