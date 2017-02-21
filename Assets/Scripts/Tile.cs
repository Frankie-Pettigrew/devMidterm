using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public enum Sides {
	Bottom,
	Right,
	Left,
	Top

}


public class Tile  {

	public int id = 0;
	public Tile[] neighbours = new Tile[4];
	public int autoTileID;

	public void AddNeighbour(Sides side, Tile tile) {
		neighbours [(int)side] = tile;
		CalculateAutotileID ();

	}

	private void CalculateAutotileID() {

		var sideValues = new StringBuilder ();
		foreach (Tile tile in neighbours) {
			sideValues.Append (tile == null ? "0" : "1");

		}
		autoTileID = Convert.ToInt32 (sideValues.ToString (), 2);
	}

}