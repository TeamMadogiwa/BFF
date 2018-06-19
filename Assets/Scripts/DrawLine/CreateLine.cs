using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour {

	[SerializeField]
	GameObject drawLine;

	List<GameObject> list = new List<GameObject>();
	GameObject draw = null;

	Transform cashedTransform;
	
	public float MAX_DRAW_AMOUNT = 100.0f;
	public float DRAW_HEAL = 1.0f;
	public float NEED_DRAW = 1.0f;
	public float drawAmount;
	public bool drawFlg = true;

	int lineCount = 1;
	// Use this for initialization
	void Awake()
	{
		cashedTransform = this.transform;
		drawAmount = MAX_DRAW_AMOUNT;
	}
	
	// Update is called once per frame
	void Update () {

		if(drawAmount < MAX_DRAW_AMOUNT && drawFlg) drawAmount += DRAW_HEAL;

		if (Input.GetMouseButtonDown(0))
		{	
			if(drawAmount > .0f)
			{
				draw = Instantiate(drawLine, cashedTransform);
				list.Add(draw);
			}
		}
		if(Input.GetMouseButton(0))
		{
			if(drawAmount > .0f && draw)
			{
				draw.GetComponent<DrawLine>().Draw();
				drawAmount -= NEED_DRAW;
				drawFlg = false;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			drawFlg = true;
		}
	}

	public void Reset()
	{
		for(int i = 0; i < list.Count; i++)
		{
			Destroy(list[i]);
		}
		list.Clear();

		drawAmount = MAX_DRAW_AMOUNT;
	}
}
