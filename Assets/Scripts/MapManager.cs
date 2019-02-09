using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{

	[Header("Environment speed")]
	public int Speed;
	[Header("Number of environment to spawn")]
	public int nEnv;
	public float padding = 100f; // distance between the environments
	public bool descending; // Bool to test when the plane descends
	
	[Header("Environments Prefabs")]
	public GameObject[] Envs;

    private List<GameObject> EnvList;
	private Vector3 dir; 
	private Vector3 lastPosCoord;
	private GameObject envToDestroy;
	private GameObject plane;
	
	

	void Start()
	{
		InitialiseEnv();
		dir = new Vector3(-1f, 0f,0f);
		lastPosCoord = new Vector3(EnvList[nEnv-1].transform.position.x, EnvList[nEnv-1].transform.position.y, EnvList[nEnv-1].transform.position.z);
		plane = GameObject.FindWithTag("Plane");
	}

	void Update()
	{
		MoveEnv();
		MoveEnvToPlane();
	}


	/*******************************************************************/
	
	// Function to spawn all the needed environments	
	void InitialiseEnv()
	{
		EnvList = new List<GameObject>(); // Init List
		
		for (int i = 0; i < nEnv; i++)
		{
			EnvList.Add(Instantiate(Envs[Mathf.Abs(Random.Range(0, Envs.Length))], new Vector3(i*padding, 0f, 0f), Quaternion.identity)); // Adding Elements to list	
		}
	}

	// Function to move the environments in the opposite direction of the plane
	void MoveEnv()
	{
		for (int i = 0; i < EnvList.Count; i++)
		{
			EnvList[i].transform.Translate(dir * Time.deltaTime * Speed);
		}

		if (EnvList[0].transform.position.x < -padding)
		{
			DeleteEnv();
			CreateNewEnv();
		}

	}

	// Function to delete the last environment which is out of the player view
	void DeleteEnv()
	{
		envToDestroy = EnvList[0];
		EnvList.RemoveAt(0);
		Destroy(envToDestroy);
	}

	// Function to create a new environment
	void CreateNewEnv()
	{
		EnvList.Add(Instantiate(Envs[Mathf.Abs(Random.Range(0, Envs.Length))], lastPosCoord, Quaternion.identity));
	}

	// Function to move environment towards the plane
	void MoveEnvToPlane()
	{
		if (plane.GetComponent<PlaneManager>().CurrentState == PlaneManager.State.Descending)
		{
			for (int i = 0; i < EnvList.Count; i++)
			{
				if (EnvList[i].transform.position.y <= plane.transform.position.y)
				{
					EnvList[i].transform.Translate(new Vector3(0, 0.8f, 0) * Speed * Time.deltaTime);
				}
				else
				{
					break;
				}
			}
			lastPosCoord = new Vector3(EnvList[nEnv-1].transform.position.x, EnvList[nEnv-1].transform.position.y, EnvList[nEnv-1].transform.position.z);
		}
	}
}
