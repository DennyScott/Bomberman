﻿using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	#region Public Methods
	public GameObject Wall;
	public GameObject GridSquare;
	public GameObject floor;
	public int HorizontalCubes;
	public int VerticalCubes;
	#endregion

	#region Private Methods

	private float _cubeWidth;
	private float _cubeHeight;
	private GameObject[,] _map;
	private float _topMap;
	private float _leftMap;

	#endregion

	#region Standard Methods
	// Use this for initialization
	void Start () {
		CalculateMapSizes();
		_map = new GameObject[VerticalCubes, HorizontalCubes];
		CreateGrid();
	}
	#endregion

	#region Private Methods
	void CalculateMapSizes() {
		WallWidth = Wall.transform.localScale.x;
		WallHeight = Wall.transform.localScale.y;
		FloorWidth = WallWidth;
		FloorHeight = WallWidth;
		_cubeHeight = FloorHeight/VerticalCubes;
		_cubeWidth = FloorHeight/HorizontalCubes;
	}

	void CreateGrid() {
		for (var i = 0; i < VerticalCubes; i++) {
			CreateRow(i);
		}
	}

	void CreateRow(int row) {
		for (var i = 0; i < HorizontalCubes; i++) {
			var square = Instantiate(GridSquare);
			var gridSquareRenderer = GridSquare.GetComponent<Renderer>().bounds.size;
			square.transform.localScale = new Vector3(gridSquareRenderer.x, gridSquareRenderer.y, 1);
			_map[row, i] = square;
			PlaceSquare(row, i, square);
		}
	}

	void PlaceSquare(int row, int col, GameObject square) {
		var WallBuffer = WallWidth/2.0f; //Half the size of the wall, to take from center to edge.
		var SquareSize = square.transform.localScale.x;
		var verticalPosition = (FloorHeight*SquareSize) / ( GridSquare.transform.localScale.x) - row * SquareSize;
		var horizontalPosition = (FloorHeight*SquareSize) / (GridSquare.transform.localScale.x) - col * SquareSize - WallBuffer * (GridSquare.transform.localScale.x);
		square.SetActive(true);
		square.transform.position = new Vector3(verticalPosition, horizontalPosition, gameObject.transform.position.z);

	}
	#endregion

	#region Properties
	public float WallWidth { get; set; }
	public float WallHeight { get; set; }
	public float FloorWidth { get; set; }
	public float FloorHeight { get; set; }
	#endregion

}
