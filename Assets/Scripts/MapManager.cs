using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapManager : MonoBehaviour
{

	public int Speed;
	public GameObject Env;
	public int nEnv;
    public float padding = 100f;

    private List<GameObject> EnvList;
	private Vector3 dir = new Vector3(-1f, 0f,0f);
	private Vector3 lastPosCoord;
	private GameObject envToDestroy;

	void Start()
	{
		InitialiseEnv();
		lastPosCoord = new Vector3(EnvList[nEnv-1].transform.position.x, EnvList[nEnv-1].transform.position.y, EnvList[nEnv-1].transform.position.z);
		print(lastPosCoord);
	}

	void Update()
	{
		MoveEnv();
	}


	/*******************************************************************/
	
	
	void InitialiseEnv()
	{
		EnvList = new List<GameObject>(); // Init List
		
		for (int i = 0; i < nEnv; i++)
		{
			EnvList.Add(Instantiate(Env, new Vector3(i*padding, 0f, 0f), Quaternion.identity)); // Adding Elements to list
		}
	}

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

	void DeleteEnv()
	{
		envToDestroy = EnvList[0];
		EnvList.RemoveAt(0);
		Destroy(envToDestroy);
	}

	void CreateNewEnv()
	{
		EnvList.Add(Instantiate(Env, lastPosCoord, Quaternion.identity));
	}

}
