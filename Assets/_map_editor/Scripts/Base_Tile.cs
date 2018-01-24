using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Tile : MonoBehaviour {
      
    //public Dictionary<string, Sprite> spriteOverlayList = new Dictionary<string, Sprite>();
    public Sprite[] spriteOverlayList;
    public GameObject spriteOverlay;

    private SpriteRenderer spriteOverlayRenderer;
    private Vector3 tileCoords;

    void Awake()
    {
        spriteOverlayRenderer = spriteOverlay.GetComponent<SpriteRenderer>();
    }
    
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
                
    }

    void OnMouseOver()
    {
        spriteOverlayRenderer.sprite = spriteOverlayList[0];
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        spriteOverlayRenderer.sprite = null;
        Debug.Log("Mouse is no longer on GameObject.");
    }

}
