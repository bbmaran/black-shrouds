using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class HexGrid : MonoBehaviour {

	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	Sprite defaultSprite;
	Canvas gridCanvas;

	HexCell[] cells;

	void Awake() {
		gridCanvas = GetComponentInChildren<Canvas>();

		cells = new HexCell[height * width];

		for (int y = 0, i = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, y, i++);
			}
		}
	}		

	void CreateCell(int x, int y, int i) {
		Vector2 position;
		position.x = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f);
		position.y = y * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);

		if (x > 0) {
			cell.SetNeighbor(HexDirection.W, cells[i - 1]);
		}
		if (y > 0) {
			if ((y & 1) == 0) {
				cell.SetNeighbor(HexDirection.SE, cells[i - width]);
				if (x > 0) {
					cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
				}
			}
			else {
				cell.SetNeighbor(HexDirection.SW, cells[i - width]);
				if (x < width - 1) {
					cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
				}
			}
		}

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(position.x, position.y);
		label.text = cell.coordinates.ToStringOnSeparateLines();
	}

	//Coloring cells in map editor 
	public void ColorCell(Vector3 position, RaycastHit2D hit, Sprite sprite) {
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);

		int index = coordinates.X + coordinates.Y * width + coordinates.Y / 2;
		HexCell cell = cells[index];
		cell.SetBaseSprite(sprite);		

		Debug.Log("touched at " + coordinates.ToString()
			+ "Target Position: " + position);
	}


}

