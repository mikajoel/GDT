﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle_1 : MonoBehaviour {

	public int castleHealth = 100;
	public Slider castleHealthSlider;

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Minion"){
			castleHealth -= 5;
			Debug.Log(castleHealth);
			Destroy(other.gameObject);
		}
	}

	void Update(){
		castleHealthSlider.value = castleHealth;
	}
}
