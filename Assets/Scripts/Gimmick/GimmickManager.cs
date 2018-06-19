using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private GameObject move;

	private List<GameObject> obstacles = null;

	private readonly float rangeX = 2.5f;
	private readonly float rangeY = 100.0f;

	private int obstacleGroupCount = 0;
	private readonly int ObstacleMax = 20;
	private readonly float adjustY = 2.0f;

	private GimmickManager(){}
	private static GimmickManager mInstance;
	public static GimmickManager Instance
	{
		get{
			if( mInstance == null )
			{
				mInstance = (GimmickManager)FindObjectOfType(typeof(GimmickManager));

				//シーン内に存在しない場合はエラー
				if (mInstance == null)
				{
					Debug.LogError (typeof(GimmickManager) + " is nothing");
				}
			}
			return mInstance;
		}
		private set{}
	}

	void Awake()
	{
		//存在しているインスタンスが自分であれば問題なし
		if(this == Instance){
		return;
		}
		//自分じゃない場合は重複して存在しているので、エラー
		Debug.LogError (typeof(GimmickManager) + " is duplicated");
  }
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	public void Create()
	{
		if( obstacles == null)
			obstacles  = new List<GameObject>();

		GameObject parentObject = new GameObject("ObstacleObjects"+obstacleGroupCount.ToString());
		parentObject.transform.position = new Vector3(.0f,-rangeY*obstacleGroupCount,.0f);
		obstacles.Add(parentObject);
		float len = rangeY / ObstacleMax;
		for (int i = 1; i < ObstacleMax+1; i++)
		{
			Generate(parentObject.transform,i*len);
		}
		obstacleGroupCount++;
	}

	private void Generate(Transform parent,float pos_y)
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
		float y = -pos_y + Random.Range(-adjustY,adjustY);

		obj.transform.localPosition = new Vector3(x,y,.0f);
	}

	public void GimmickDestroy()
	{
		if( obstacles == null)
			return;
		for (int i = 0; i < obstacles.Count; i++)
		{
			Destroy(obstacles[i]);
		}
		obstacles.Clear();
		obstacleGroupCount = 0;
	}
}
