using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	public float startTimer = 60f; //Amount of time the player's have to place defences
	public int wave; //What wave the player's have got to
	public int amountOfSpawns;
	public GameObject angel, minion; //The minion/angel prefabs
	public GameObject angelPos, minionPos; //the minion/angel spawn locations

	public bool waveSpawning = false; //has the wave finsihed spawning?
	public bool started; //Countdown finished and game has started

	// Use this for initialization
	void Start () {
		wave = 1; //Begin game with wave 1
		amountOfSpawns = 5;
	}

	void Update(){
		startTimer -= 1f * Time.deltaTime; //Countdown to wave 1
		amountOfSpawns = wave * 5; //amount of spawns
		//if the timer reaches 0, begin the wave
		if(startTimer <= 0f && waveSpawning == false && started == false){
			started = true;
			wave++;
			StartCoroutine(SpawnWave());
		}
		//If wave is complete:
		if(GameObject.FindGameObjectsWithTag("Angel").Length == 0 && GameObject.FindGameObjectsWithTag("Minion").Length == 0 && started == true){
			startTimer = 60;
			started = false;
		}
	}
	
	// Update is called once per frame
	IEnumerator SpawnWave () {
		//Spawn the amount of angels/minions as required for the wave
		for(int i = 0; i < amountOfSpawns; i++){
			Instantiate(angel, angelPos.transform.position, Quaternion.identity);
			Instantiate(minion, minionPos.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(0.75f);
		}
		
	}
}
