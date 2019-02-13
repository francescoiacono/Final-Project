using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining and controlling Plane Movements

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

        // Switching state
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
		if (Mathf.Floor(transform.localEulerAngles.x) != Angle)
			transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);

        SoundManager.Instance.PlaySound("brace");
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
        int x = (int)Mathf.Floor(transform.localEulerAngles.x);
        if (x != 0)
		{
            if(x >= 360 - Angle)
                transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            else if (x <= Angle)
                transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime);
        }
	}

    /******************************CollisionDetection*********************************/




}
