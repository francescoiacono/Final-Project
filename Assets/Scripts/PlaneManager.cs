using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining and controlling Plane Movements

public class PlaneManager : MonoBehaviour
{

	[Header("Plane Settings")] 
	public Vector3 PlanePosition;
    public float MaxSpeed;
    public float Acceleration;
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

    [Header("Path")]
    public Transform[] PathPoints;
    public bool followingPath;

    private bool up;
	private bool stable;
    private float speed;
    private int k;
	/***************************************************************************************************************/
	
	void Start()
	{	
		transform.position = PlanePosition;
		CurrentState = State.Stable;
        speed = 0;
        k = 0;
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

        followPath(PathPoints[k]);
	}

    // follow path
    void followPath(Transform path) {
        if (followingPath)
        {
            if (Vector3.Distance(transform.position, path.position) > 0)
            {
                if (speed < MaxSpeed)
                {
                    speed = speed + Acceleration * Time.deltaTime;
                } else {
                    speed = MaxSpeed;
                }

                if (k == 2) {
                    CurrentState = State.Ascending;
                }

                print(speed);
                transform.position = Vector3.MoveTowards(transform.position, path.position, speed * 0.5f);
            }
            else {
                k++;
            }
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
            stable = false;
            if (x >= 360 - Angle)
                transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            else if (x <= Angle)
                transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime);
        }
        stable = true;
    }

    // TODO FIX FLOATING
    void Floating()
	{
		StartCoroutine(floatUp(1f));
		StartCoroutine(floatDown(1f));
	}

	// TODO fix floating
	
	private IEnumerator floatUp(float time)
	{
		yield return new WaitForSeconds(time);
		transform.Translate(new Vector3(0f,0.1f,0f));
	}
	
	private IEnumerator floatDown(float time)
	{
		yield return new WaitForSeconds(time);
		transform.Translate(new Vector3(0f,-0.1f,0f));
	}
	



}
