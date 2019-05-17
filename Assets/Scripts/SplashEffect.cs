using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{

    // NB: THIS SCRIPT WAS USED IN THE PROTOTYPE

	public GameObject SplashObject; // Set to be the prefab of the splash object
	public int MaxSplashObjects; // Maximun number of splash objects
	public float LifeTime; // Their life span
	
	private List<Rigidbody> rbs; // List of rigid bodies, it will contain the physics component of every
    //                              splash object and apply forces to them
	private List<GameObject> splashObjects; // List of splash objects
	private float x = 15f; // This is a range, it will move the objects around -x and x. 
	public bool stop; // Stop creating objects

	private void Awake()
	{
	}

	private void Start()
	{
		rbs = new List<Rigidbody>();
		splashObjects = new List<GameObject>();
	}

	public void Splash()
	{	
        // Function to create objects, apply force to them and then realise when they need to be destroyed.
		if (!stop)
		{
			for (int i = 0; i < MaxSplashObjects; i++)
			{
				splashObjects.Add(Instantiate(SplashObject, transform.position, Quaternion.identity));
				rbs.Add(splashObjects[i].GetComponent<Rigidbody>());
				rbs[i].AddForce(new Vector3(Random.Range(-x, x), Random.Range(-x, x), Random.Range(-x, x)),
					ForceMode.Impulse);
			}

			stop = true;
			StartCoroutine(WaitAndKill(LifeTime));
		}
	}

    // Function to destroy the splash objects
	private IEnumerator WaitAndKill(float lifeTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(lifeTime);
			if (splashObjects.Count > 0)
			{
				foreach (GameObject splash in splashObjects)
				{
					Destroy(splash);
				}
			}
		}
	}

}
