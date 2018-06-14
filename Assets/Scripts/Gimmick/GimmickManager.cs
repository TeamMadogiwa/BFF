using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
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
}
