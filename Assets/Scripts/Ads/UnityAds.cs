using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
	private static UnityAds mInstance;

	private string gameID;

	public System.Action callbackReward = null;
	private UnityAds(){}
	public static UnityAds Instance
	{
		get{
			if( mInstance == null )
			{
				GameObject obj = new GameObject("UnityAds");
                mInstance = obj.AddComponent<UnityAds>();

				if( Advertisement.isSupported )
					Advertisement.Initialize(mInstance.gameID,true);
			}
			return mInstance;
		}
		private set{}
	}

	public void ShowRewardedVideo ()
	{
		if( !Advertisement.IsReady(gameID))
		{
			Debug.Log("広告のロードが終わっていません");
		}
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;	

		Advertisement.Show(gameID, options);
	}

	public void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished)
		{
			Debug.Log("Video completed - Offer a reward to the player");
			callbackReward?.Invoke();
		}
		else if(result == ShowResult.Skipped)
		{
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
		}
		else if(result == ShowResult.Failed)
		{
			Debug.LogError("Video failed to show");
		}
	}
}
