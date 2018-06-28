using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action : MonoBehaviour
{
	Transform cashedTransform;

	private Rigidbody2D rigidbody;
	
	public float moveY = .0f;
	[SerializeField]
	Text scoreText;

	public System.Action ReturnStart = null;

	bool isAlive = true;
	
	private readonly float MaxSpeed = 5.0f;
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveY = -(rigidbody.position.y -3);
		scoreText.text = ((int)moveY).ToString();
	}

	public void Finished()
	{
		ReturnStart?.Invoke();
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		// if( rigidbody.velocity.magnitude > MaxSpeed )
		// {
		// 	rigidbody.velocity = rigidbody.velocity.normalized * MaxSpeed;
		// }
	}

	public int Score()
	{
		return (int)moveY;
	}

	public void SetHighScore(int score)
	{
		Debug.Log(score);
		scoreText.text = score.ToString();
	}
}
