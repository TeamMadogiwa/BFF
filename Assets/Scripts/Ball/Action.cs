﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
	Transform cashedTransform;

	private Rigidbody2D rigidbody;
	
	private readonly float MaxSpeed = 5.0f;
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		if( rigidbody.velocity.magnitude > MaxSpeed )
		{
			rigidbody.velocity = rigidbody.velocity.normalized * MaxSpeed;
		}
	}
}
