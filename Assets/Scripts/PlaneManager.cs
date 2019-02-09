using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{

	[Header("Plane Heading")]
	public float RotationSpeed;
	
	public enum State
	{
		Stable,
		Descending,
		Ascending
	}
	[Header("Plane State")]
	public State CurrentState;

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
		gameObject.transform.Rotate(new Vector3(1f,0f,0f)*RotationSpeed*Time.deltaTime);
	}

	
	// Function to ascend
	void PlaneAsceding()
	{
		gameObject.transform.Rotate(new Vector3(-1f,0f,0f)*RotationSpeed*Time.deltaTime);
	}

	// Function to stabilise the plane
	void PlaneStable()
	{
		if (gameObject.transform.rotation.x > 0f)
		{
			gameObject.transform.Rotate(new Vector3(-0.5f,0f,0f)*RotationSpeed*Time.deltaTime);
		}
		else if (gameObject.transform.rotation.x < 0f)
		{
			gameObject.transform.Rotate(new Vector3(0.5f,0f,0f)*RotationSpeed*Time.deltaTime);
		}
		else
		{
			print("Stable");
		}
	}

}
