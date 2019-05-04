using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

// Moving map around the plane

public class MapManager : MonoBehaviour
{

	[Header("Environment speed")]
    public float SpeedX;
	public float SpeedY;

	[Header("Number of environment to spawn")]
	public int nEnv;

	public float padding = 100f; // distance between the environments

	[Header("Environments Prefabs")] public GameObject[] Envs;

	private List<GameObject> EnvList;
	private Vector3 dir;
	private Vector3 lastPosCoord;
	private GameObject envToDestroy;
	private GameObject plane;
    private SoundManager sm;

	/*************************Init+Update******************************/

	void Start()
	{
		InitialiseEnv();
		dir = new Vector3(-1f, 0f, 0f);
		lastPosCoord = new Vector3(EnvList[nEnv - 1].transform.position.x, EnvList[nEnv - 1].transform.position.y,
			EnvList[nEnv - 1].transform.position.z);
		plane = GameObject.FindWithTag("Plane");
        //sm = SoundManager.Instance;
	}

void Update()
	{
		MoveEnv();
		MoveEnvToPlane();
    }


	/**************************MyFunctions****************************/
	
	// Function to spawn all the needed environments	
	void InitialiseEnv()
	{
		EnvList = new List<GameObject>(); // Init List

		for (int i = 0; i < nEnv; i++)
		{
			EnvList.Add(Instantiate(Envs[Mathf.Abs(Random.Range(0, Envs.Length))], new Vector3(i * padding, 0f, 0f),
				Quaternion.identity)); // Adding Elements to list	
		}
	}

	// Function to move the environments in the opposite direction of the plane
	void MoveEnv()
	{
		for (int i = 0; i < EnvList.Count; i++)
		{
			EnvList[i].transform.Translate(dir * Time.deltaTime * SpeedX);
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
                    EnvList[i].transform.Translate(new Vector3(0, 1f, 0) * plane.transform.localEulerAngles.x * SpeedY * Time.deltaTime);
				}
				else
				{
					break;
				}
			}
			lastPosCoord.y = EnvList[nEnv-1].transform.position.y; // Updating Y position
		    
		}
	}
}
