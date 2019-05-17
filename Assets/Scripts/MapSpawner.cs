using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script has been used in order to develop a nice map
// It places the prefab tiles into the environment and apply the sprites needed

public class MapSpawner : MonoBehaviour {
    
    public List<Sprite> sprites; // All the sprites
    public GameObject MapTile; // MapTile prefab
    private int numY; // Moving on the Y axis
    private int numX; // Moving on X axis

    // For each sprite in sprites, instantiate a new maptile with the current sprite.

    void Start () {
        numX = 0;
        numY = 0;

        for (int i = 4498; i < sprites.Count; i++) {
            MapTile.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprites[i];
            GameObject tile = Instantiate(MapTile, new Vector3(50f * numX, 0f, 50f * numY), Quaternion.identity);
            tile.name = i + "";
            numX++;
            if (numX % 26 == 0) {
                numY++;
                numX = 0;
            }
        }
	}
	
	void Update () {
		
	}
}
