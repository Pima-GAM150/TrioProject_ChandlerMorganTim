using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorChange : MonoBehaviour {

	public Sprite blue;
	public Sprite red;
	public Sprite green;
	public Sprite white;

	public SpriteRenderer platform;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerController.playerModeSelect == 1) {
			platform.sprite = blue;
		}
		if (PlayerController.playerModeSelect == 2) {
			platform.sprite = red;
		}
		if (PlayerController.playerModeSelect == 3) {
			platform.sprite = green;
		}
		if (PlayerController.playerModeSelect == 0) {
			platform.sprite = white;
		}
	}
}
