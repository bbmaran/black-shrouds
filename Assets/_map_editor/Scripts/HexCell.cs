using UnityEngine;

public class HexCell : MonoBehaviour {
	
	public HexCoordinates coordinates;

	public GameObject spriteBase;
	SpriteRenderer spriteBaseRenderer;

	PolygonCollider2D cellCollider;	

	Ray ray;
	RaycastHit hit;

	void Awake() {
		cellCollider = GetComponent<PolygonCollider2D>();
		cellCollider.points = HexMetrics.corners;

		//spriteBaseRenderer = GetComponent<SpriteRenderer>();
		//SetBaseSprite(baseSprite);
		//baseSprite = spriteBaseRenderer.GetComponent<SpriteRenderer>().sprite;
	}


	public void SetBaseSprite(Sprite sprite) {
		spriteBase.GetComponent<SpriteRenderer>().sprite = sprite;
	}

	//void OnMouseDown() {
	//	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	//	if (Physics.Raycast(ray, out hit)) {
	//		Debug.Log(hit.collider.name);
	//	}

	//	spriteOverlayRenderer.sprite = spriteOverlayList[0];
	//}

	//void OnMouseExit() {
	//	spriteOverlayRenderer.sprite = null;
	//}

	//void TouchCell(Vector3 position) {
	//	position = transform.InverseTransformPoint(position);
	//	HexCoordinates coordinates = HexCoordinates.FromPosition(position);
	//	Debug.Log("touched at " + coordinates.ToString());
	//}


}
