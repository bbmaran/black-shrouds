using UnityEngine;

public class HexCell : MonoBehaviour {

	public PolygonCollider2D cellCollider;

	public HexCoordinates coordinates;

	void Awake() {
		cellCollider = GetComponent<PolygonCollider2D>();

		cellCollider.points = HexMetrics.corners;
	}
}
