using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawner : MonoBehaviour {

    public List<Sprite> sprites;
    public GameObject MapTile;
    private int numY;
    private int numX;

    // Use this for initialization
    void Start () {
        numX = 0;
        numY = 0;

        for (int i = 3044; i < sprites.Count; i++) {
            MapTile.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprites[i];
            GameObject tile = Instantiate(MapTile, new Vector3(-50f * numX, 0f, -50f * numY), Quaternion.identity);
            tile.name = i + "";
            numX++;
            if (numX % 50 == 0) {
                numY++;
                numX = 0;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
