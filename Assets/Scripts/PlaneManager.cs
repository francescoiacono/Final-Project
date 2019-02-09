using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{

	public float RotationSpeed;
	public bool Descending;
	public bool Ascending;
	public bool Stable;
	
	// Update is called once per frame
	void Update () {

		switch (hideFlags)
		{
				
		}
		
	}

	void PlaneDescending()
	{
		gameObject.transform.Rotate(new Vector3(-1f,0f,0f)*RotationSpeed*Time.deltaTime);
	}

	void PlaneAsceding()
	{
		gameObject.transform.Rotate(new Vector3(1f,0f,0f)*RotationSpeed*Time.deltaTime);
	}

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
