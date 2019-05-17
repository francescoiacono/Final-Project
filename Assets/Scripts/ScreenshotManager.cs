using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 58px for next tile
// 49*58 for the x
// 40*58 for the y

public class ScreenshotManager : MonoBehaviour {

    private int numX; // following x axis
    private int numZ; // following z axis
    public Camera ScreenshotCamera; // Camera that takes the screenshots
    public bool StartScreenshots; // Variable to start the screenshots
    private bool finished; // Checking if the screenshots are completed
    private int total; // Total number of screenshots

	void Start () {
        numX = 0;
        total = 4498;
        numZ = 1;
        finished = true;
	}

    void Update()
    {
        // Start taking screenshot
        if (StartScreenshots) { 
            if (finished)
            {
                StartCoroutine(TakeScreenshot());
            }
        }

	}

    // Take screenshot function which will move the camera, tile by tile, take the screenshot
    // and save the file as a png
    IEnumerator TakeScreenshot() {
        finished = false;

        if (ScreenshotCamera.transform.position.x >= 1450) {
            numZ++;
            numX = 0;
            Debug.Log("Increasing Y");
        }

        if (ScreenshotCamera.transform.position.z <= -870) {
            StartScreenshots = false;
        }

        ScreenshotCamera.transform.position = new Vector3(58 * numX, ScreenshotCamera.transform.position.y, -numZ*58);
        yield return new WaitForSeconds(2f);
        ScreenCapture.CaptureScreenshot("Assets/MapTextures/Test" + total + ".png");
        Debug.Log("Screenshot Taken! " + " Num: " + numX + " total: " + total );
        numX++;
        total++;
        finished = true;
    }

}
