using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Camera playerCamera;

	float movementRate = 1.15f;

	bool inFight = false;
	float zoomRate = 7.5f;
	float minCameraOrtSize = 20;
	float maxCameraOrtSize = 40;

	void Awake () {
		playerCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
			moveCamera();
		}
		
		if (Input.GetAxisRaw("Mouse ScrollWheel") != 0 && !inFight) {
			zoomCamera();
		}
		//Debug.Log("camera position: " + playerCamera.transform.position);
	}

	void moveCamera() {
		float moveX = Input.GetAxisRaw("Horizontal") * movementRate;
		float moveY = Input.GetAxisRaw("Vertical") * movementRate;
		playerCamera.transform.Translate(moveX, moveY, 0); 
	}

	void zoomCamera() {
		float zoom = - Input.GetAxis("Mouse ScrollWheel")* zoomRate;
		//playerCamera.orthographicSize += zoom;
		playerCamera.orthographicSize = Mathf.Clamp(playerCamera.orthographicSize + zoom, minCameraOrtSize, maxCameraOrtSize);
	}
	//Mouse ScrollWheel
}
