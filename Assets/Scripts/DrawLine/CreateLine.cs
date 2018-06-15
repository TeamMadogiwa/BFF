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
		if(!draw)
		{
			cashedTransform = this.transform;
			cashedTransform.position = new Vector3(.0f, .0f, .0f);
			draw = Instantiate(drawLine, this.transform);
			Debug.Log("初期生成");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			cashedTransform = this.transform;
			cashedTransform.position = new Vector3(.0f, .0f, .0f);
			draw = Instantiate(drawLine, this.transform);
			Debug.Log("生成");
		}

		if(Input.GetMouseButton(0))
		{
			draw.GetComponent<DrawLine>().test();
		}
		
	}
}
