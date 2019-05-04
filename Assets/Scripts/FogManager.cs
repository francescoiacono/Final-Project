using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogManager : MonoBehaviour {

    // Map angle = -32

    public List<GameObject> FogTiles; // List of fog tiles
    public GameObject Plane; // Plane Object

    private Dictionary<GameObject, float> FogDictionary; // Tiles linked with their distance
    private Color col; // Temporary colour
    private float fogY; // Parent Y Position
    private bool firstTime;

    // Setting up some stuff
    void Start () {
        col = new Color();
        FogDictionary = new Dictionary<GameObject, float>();
        firstTime = true;
        fogY = GameObject.FindWithTag("Fog").transform.position.y;
    }
	
	void Update () {        
        if (FogDictionary.Count == 0)
        {
            BeginFogTiles(); // Setting up tiles
        }
        
        UpdateDistances(); // Updating distance from plane costantly
        
        if (fogY < Plane.transform.position.y)
        {
            UpdateTiles(); // Updating their colour
        }

    }

    // Adding tiles to dictionary and setting their opacity to zero
    void BeginFogTiles()
    {
        for (int i = 0; i < FogTiles.Count; i++)
        {
            FogDictionary.Add(FogTiles[i], Vector3.Distance(FogTiles[i].transform.position, Plane.transform.position));
            col = FogTiles[i].transform.Find("FogCanvas").Find("FogImage").GetComponent<Image>().color; // Setting Temp color to be the colour needed and then setting its alpha to 0
            col.a = 0;
            FogTiles[i].transform.Find("FogCanvas").Find("FogImage").GetComponent<Image>().color = col; // All the tiles are not visible now.
        }
    }

    // Update Tiles' distances from plane
    void UpdateDistances() {
        for (int i = 0; i < FogDictionary.Count; i++)
        {
            FogDictionary[FogTiles[i]] = Vector3.Distance(FogTiles[i].transform.position, Plane.transform.position);
        }
    }

    // Update tiles' colour
    void UpdateTiles() {

        for (int i = 0; i < FogTiles.Count; i++)
        {
            float thisDist = FogDictionary[FogTiles[i]] / 5000; // Distance scaled
            col = FogTiles[i].transform.Find("FogCanvas").Find("FogImage").GetComponent<Image>().color;
            if (firstTime)
            {
                if (col.a < thisDist)
                {
                    col.a += 0.005f;
                }

                // FogTilse[62] = Furthest fog tile from the plane, when the game begins.
                // In this way when the furthest tile reaches the medium point of opacity the first time that they loaded is finished
                if (FogTiles[62].transform.Find("FogCanvas").Find("FogImage").GetComponent<Image>().color.a > 0.5) {
                    firstTime = false;
                }
            }
            else
            {
                col.a = thisDist;
            }
            FogTiles[i].transform.Find("FogCanvas").Find("FogImage").GetComponent<Image>().color = col;
        }
    }


}
