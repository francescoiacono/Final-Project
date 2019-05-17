using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{

    // Script used in the prototype to start splash effect

	private PlaneManager plane;

	private SplashEffect splasheffect;	

	private void Start()
	{
		plane = GameObject.FindWithTag("Plane").GetComponent<PlaneManager>();
		splasheffect = GameObject.FindWithTag("Splasher").GetComponent<SplashEffect>();
	}

	private void OnTriggerEnter(Collider other)
	{
		splasheffect.Splash();
		plane.CurrentState = PlaneManager.State.Stable;
	}

	
}
