using UnityEngine;
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

	
	// Update is called once per frame
	void Update () {
	
	}
	#endregion

	#region Private Methods
	void CalculateMapSizes() {
		WallWidth = Wall.transform.localScale.x;
		WallHeight = Wall.transform.localScale.y;
		FloorWidth = WallHeight;
		FloorHeight = WallHeight;
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
			_map[row, i] = square;
		}
	}
	#endregion

	#region Properties
	public float WallWidth { get; set; }
	public float WallHeight { get; set; }
	public float FloorWidth { get; set; }
	public float FloorHeight { get; set; }
	#endregion

}
