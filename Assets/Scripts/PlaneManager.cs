using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{

	[Header("Plane Heading")]
	public float RotationSpeed;
	public float Angle;
	
	public enum State
	{
		Stable,
		Descending,
		Ascending
	}
	[Header("Plane State")]
	public State CurrentState;

	private bool reachedAngle;

	/***************************************************************************************************************/
	
	void Start()
	{
		CurrentState = State.Stable;
	}

	void Update () {

		switch (CurrentState)
		{
				case State.Stable:
					PlaneStable();
					break;
				case State.Descending:
					PlaneDescending();
					break;
				case State.Ascending:
					PlaneAsceding();
					break;
		}
		
	}

	// Function to descend
	void PlaneDescending()
	{
		if ((transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= 360 - Angle) || 
		    (transform.eulerAngles.x <= Angle && transform.eulerAngles.x >= 0))
		{
			transform.Rotate(new Vector3(1f, 0f, 0f) * RotationSpeed * Time.deltaTime);
		}
		else
		{
			transform.eulerAngles = new Vector3(Angle, 90f, 0f);
			print("stop des");
		}
	}



	// Function to ascend
	void PlaneAsceding()
	{
		if ((transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= 360 - Angle) || 
		    (transform.eulerAngles.x <= Angle && transform.eulerAngles.x >= 0))
		{
			transform.Rotate(new Vector3(-1f, 0f, 0f) * RotationSpeed * Time.deltaTime);
		}
		else
		{
			transform.eulerAngles = new Vector3(-Angle, 90f, 0f);
			print("stop asc");
		}
	}

	// Function to stabilise the plane
	void PlaneStable()
	{
		if (transform.rotation.x > 0f)
		{
			transform.Rotate(new Vector3(-0.5f,0f,0f)*RotationSpeed*Time.deltaTime);
		}
		else if (transform.rotation.x < 0f)
		{
			transform.Rotate(new Vector3(0.5f,0f,0f)*RotationSpeed*Time.deltaTime);
		}
		else
		{
			print("Stable");
		}
	}

}
