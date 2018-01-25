using UnityEngine;

public static class HexMetrics {

	public const float outerRadius = 3.375f; //TILE radius = 54px
	public const float innerRadius = outerRadius * 0.866025404f;

	public static Vector2[] corners = {
		new Vector2(0f, outerRadius),
		new Vector2(innerRadius, 0.5f * outerRadius),
		new Vector2(innerRadius, -0.5f * outerRadius),
		new Vector2(0f, -outerRadius),
		new Vector2(-innerRadius, -0.5f * outerRadius),
		new Vector2(-innerRadius, 0.5f * outerRadius)
	};

}