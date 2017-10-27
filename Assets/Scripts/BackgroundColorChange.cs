using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour {

	public Sprite bluedim;
	public Sprite reddim;
	public Sprite greendim;
	public Sprite whitedim;

	public SpriteRenderer backgroundplatform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerController.playerModeSelect == 1) {
			backgroundplatform.sprite = bluedim;
		}
		if (PlayerController.playerModeSelect == 2) {
			backgroundplatform.sprite = reddim;
		}
		if (PlayerController.playerModeSelect == 3) {
			backgroundplatform.sprite = greendim;
		}
		if (PlayerController.playerModeSelect == 0) {
			backgroundplatform.sprite = whitedim;
		}

	}
}
