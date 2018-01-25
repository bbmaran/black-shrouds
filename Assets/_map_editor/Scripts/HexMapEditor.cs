using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour {

	public Sprite[] sprites;
	public HexGrid hexGrid;

	private Sprite activeSprite;

	void Awake() {
		SelectSprite(0);
	}

	void Update() {
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
			HandleInput();
		}
	}

	void HandleInput() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {
			hexGrid.ColorCell(hit.point, hit, activeSprite);
		}
	}

	public void SelectSprite(int index) {
		activeSprite = sprites[index];
	}

	
}
