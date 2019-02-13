using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
	public GameObject SplashObject;
	//public static SplashEffect Instance;
	public int MaxSplashObjects;
	
	private List<Rigidbody> rbs;
	private List<GameObject> splashObjects;
	private float x = 15f;
	public bool stop;

	private void Awake()
	{
		//Instance = this;
	}

	private void Start()
	{
		rbs = new List<Rigidbody>();
		splashObjects = new List<GameObject>();
	}

	public void Splash()
	{	
		if (!stop)
		{
			print("GoingToWork");
			for (int i = 0; i < MaxSplashObjects; i++)
			{
				splashObjects.Add(Instantiate(SplashObject, transform.position, Quaternion.identity));
				rbs.Add(splashObjects[i].GetComponent<Rigidbody>());
				rbs[i].AddForce(new Vector3(Random.Range(-x, x), Random.Range(-x, x), Random.Range(-x, x)),
					ForceMode.Impulse);
			}

			stop = true;
			StartCoroutine(WaitAndKill(5f));
		}
	}

	private IEnumerator WaitAndKill(float lifeTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(lifeTime);
			if (splashObjects.Count > 0)
			{
				foreach (GameObject go in splashObjects)
				{
					Destroy(go);
				}
			}
		}
	}

}
