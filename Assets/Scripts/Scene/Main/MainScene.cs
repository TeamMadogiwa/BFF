using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour {

	[SerializeField]
	GameObject ball;
	Vector3 ballInit = new Vector3(.0f, 3.0f, .0f);

	[SerializeField]
	GameObject createLine;

	[SerializeField]
	private GameObject title;

	private bool isPlay = false;

	[SerializeField]
	private int nowLevel = 0;

    [SerializeField]
    Image bg;

    [SerializeField]
    private float hue = 0.0f;
    private float sat = 0.14777f;
    private float v = 1.0f;

    int highScore;

    // Use this for initialization
    void Awake()
	{
		ball.GetComponent<Action>().ReturnStart = StartPrepare;
		StartPrepare();
        hue = 0.608f;
        bg.color = Color.HSVToRGB(hue, sat, v);
    }

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if( !isPlay )
				GameStart();
		}

		if( isPlay )
		{
			int Count = (int)(ball.GetComponent<Action>().moveY / 100.0f);
			if( nowLevel < Count )
			{
				Debug.Log("障害物生成");
				nowLevel++;
				GimmickManager.Instance.Create();
                BGChange();
            }
		}
    }

	private void StartPrepare()
	{
		nowLevel = 0;
		isPlay = false;	
		ball.transform.position = ballInit;
		ball.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		title.SetActive(true);
		GimmickManager.Instance.GimmickDestroy();
		createLine.GetComponent<CreateLine>().Reset();
        HighScore();
        ball.GetComponent<Action>().SetHighScore(highScore);
	}
	private void GameStart()
	{
		isPlay = true;
		ball.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
		title.SetActive(false);
		for (int i = 0; i < 2; i++)
		{
			GimmickManager.Instance.Create();
		}
	}
    private IEnumerator BGChange()
    {
        float value = 0.002f;
        //HSVでHを加算してくタイプ
        for (int i = 0; i < 100; i++)
        {
            hue += value;
            if (hue > 1.0f)
                hue -= 1.0f;
            bg.color = Color.HSVToRGB(hue, sat, v);

            yield return null;
        }
    }

    void HighScore()
    {
        int score = ball.GetComponent<Action>().Score();
        int saveHighScore = PlayerPrefs.GetInt("highScore", 0);
        if(score > saveHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        } else
        {
            highScore = saveHighScore;
        }

    }
}
