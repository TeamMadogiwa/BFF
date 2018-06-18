using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour {

	[SerializeField]
	GameObject drawLine;

	GameObject draw = null;

	Transform cashedTransform;
	
	int lineCount = 1;
	// Use this for initialization
	void Awake()
	{
		cashedTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			draw = Instantiate(drawLine, cashedTransform);
		}

		if(Input.GetMouseButton(0))
		{
			draw.GetComponent<DrawLine>().test();
		}

		if(draw) draw.GetComponent<DrawLine>().AliveTime();
	}
}
