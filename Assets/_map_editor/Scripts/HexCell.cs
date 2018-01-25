using UnityEngine;

public class HexCell : MonoBehaviour {

	[SerializeField]
	HexCell[] neighbors;

	public HexCoordinates coordinates;

	public GameObject spriteOverlay;
	public GameObject spriteBase;

	PolygonCollider2D cellCollider;	

	Ray ray;
	RaycastHit hit;

	void Awake() {
		cellCollider = GetComponent<PolygonCollider2D>();
		cellCollider.points = HexMetrics.corners;
	}

	public void SetOverlaySprite(Sprite sprite) {
		spriteOverlay.GetComponent<SpriteRenderer>().sprite = sprite;
	}

	public void SetBaseSprite(Sprite sprite) {
		spriteBase.GetComponent<SpriteRenderer>().sprite = sprite;
	}

	public HexCell GetNeighbor(HexDirection direction) {
		return neighbors[(int)direction];
	}

	public void SetNeighbor(HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()] = this;
	}
}
