using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 58px for next tile
// 49*58 for the x
// 40*58 for the y

public class ScreenshotManager : MonoBehaviour {

    private int numX;
    private int numZ;
    public Camera ScreenshotCamera;
    public bool StartScreenshots;
    private bool finished;
    private int total;

	// Use this for initialization
	void Start () {
        numX = 0;
        total = 2002;
        numZ = 0;
        finished = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (StartScreenshots) { 
            if (finished)
            {
                StartCoroutine(TakeScreenshot());
            }
        }

	}

    IEnumerator TakeScreenshot() {
        finished = false;

        if (ScreenshotCamera.transform.position.x >= 1450) {
            numZ++;
            numX = 0;
            Debug.Log("Increasing Y");
        }

        if (ScreenshotCamera.transform.position.z >= 2320){
            StartScreenshots = false;
        }

        ScreenshotCamera.transform.position = new Vector3(58 * numX, ScreenshotCamera.transform.position.y, numZ*58);
        yield return new WaitForSeconds(2f);
        ScreenCapture.CaptureScreenshot("Assets/MapTextures/Test" + total + ".png");
        Debug.Log("Screenshot Taken! " + " Num: " + numX + " total: " + total );
        numX++;
        total++;
        finished = true;
    }

}
