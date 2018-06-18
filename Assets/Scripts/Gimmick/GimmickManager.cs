using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private GameObject move;

	private readonly float rangeX = 2.5f;
	private readonly float rangeY = 20.0f;

	private int obstacleGroupCount = 0;
	private readonly int ObstacleMax = 10;

	private static GimmickManager mInstance;
	public static GimmickManager Instance
	{
		get{
			if( mInstance == null )
			{
				GameObject obj = new GameObject("GimmickManager");
                mInstance = obj.AddComponent<GimmickManager>();
			}
			return mInstance;
		}
		private set{}
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	public void Create()
	{
		GameObject parentObject = new GameObject("ObstacleObjects"+obstacleGroupCount.ToString());
		parentObject.transform.position = new Vector3(.0f,-rangeY*2*obstacleGroupCount,.0f);
		for (int i = 0; i < ObstacleMax; i++)
		{
			Generate(parentObject.transform);
		}
		obstacleGroupCount++;
	}

	private void Generate(Transform parent)
	{
		int select = Random.Range(0,100);

		GameObject obj = null;
		if ( select < 50 )
		{
			obj = GameObject.Instantiate(needle,parent);
		}
		else
		{
			obj = GameObject.Instantiate(move,parent);
		}

		float x = Random.Range(-rangeX,rangeX);
		float y = Random.Range(-rangeY,rangeY);

		obj.transform.localPosition = new Vector3(x,y,.0f);
	}
}
