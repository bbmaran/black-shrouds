using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class HexGrid : MonoBehaviour {

	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	public Sprite greenSprite;
	public Sprite yellowSprite;
	public Sprite blueSprite;

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
		cell.SetBaseSprite(greenSprite);

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(position.x, position.y);
		label.text = cell.coordinates.ToStringOnSeparateLines();
	}

	//TOUCHING SHIT
	void Update() {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

	void HandleInput() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {
			TouchCell(hit.point, hit);
		}
	}

	void TouchCell(Vector3 position, RaycastHit2D hit) {
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);

		int index = coordinates.X + coordinates.Y * width + coordinates.Y / 2;
		HexCell cell = cells[index];
		cell.SetBaseSprite(yellowSprite);
		

		Debug.Log("touched at " + coordinates.ToString()
			+ "Target Position: " + position
			+ "Collider name: " + hit.collider.name);
		//spriteOverlayRenderer.sprite = spriteOverlayList[0];
		//Debug.Log("Target Position: " + position);
	}
}

