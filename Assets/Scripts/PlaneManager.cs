using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{

	[Header("Plane Settings")] 
	public Vector3 PlanePosition;
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

	/***************************************************************************************************************/
	
	void Start()
	{	
		transform.position = PlanePosition;
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
		
		print("angle: " + transform.eulerAngles);

		
	}

	// Function to descend
	void PlaneDescending()
	{
		if (Mathf.Floor(transform.localEulerAngles.x) != Angle)
			transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
	}



	// Function to ascend
	void PlaneAsceding()
	{
		if (Mathf.Floor(transform.localEulerAngles.x) != 360 - Angle)
			transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime);
	}

	// Function to stabilise the plane
	void PlaneStable()
	{
		if (Mathf.Floor(transform.localEulerAngles.x) != 0)
		{
			Vector3 stabilizer = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.localEulerAngles =
				Vector3.Lerp(transform.localEulerAngles, stabilizer, RotationSpeed * Time.deltaTime);
		}
	}

}
