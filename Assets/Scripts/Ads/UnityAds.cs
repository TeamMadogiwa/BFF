using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
	private static UnityAds mInstance;

	private UnityAds(){}
	public static UnityAds Instance
	{
		get{
			if( mInstance == null )
			{
				GameObject obj = new GameObject("UnityAds");
                mInstance = obj.AddComponent<UnityAds>();
			}
			return mInstance;
		}
		private set{}
	}
}
