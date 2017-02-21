using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapTester : MonoBehaviour {


	[Header("Map Dimensions")]
	public int mapWidth = 20;
	public int mapHeight = 20;

	[Space]
	[Header("Visualize Map")]
	public GameObject mapContainer;
	public GameObject roadPrefab;
	public Vector2 tileSize = new Vector2 (16, 16);

	public Map map;

	// Use this for initialization
	void Start () {
		map = new Map ();
	}
	
	public void MakeMap() {
		map.NewMap (mapWidth, mapHeight);
		Debug.Log ("Created a new " + map.columns + "x" + map.rows + " map");
		CreateGrid ();
	}

	void CreateGrid() {
		var total = map.tiles.Length;
		var maxColumns = map.columns;
		var column = 0;
		var row = 0;

		for (var i = 0; i < total; i++) {

			column = i % maxColumns;
			var newX = column * tileSize.x;
			var newY = -row * tileSize.y;

			var Go = Instantiate (roadPrefab);
			Go.name = "Tile " + i;
			Go.transform.SetParent (mapContainer.transform);
			Go.transform.position = new Vector3 (newX, newY, 0);

			if (column == (maxColumns - 1)) {
				row++;
			}

		}


	}

}
