using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour {

	public GameObject[] waypoints;
	public float speed = 1f;
	public float rotateSpeed;
	public int currentWaypoint = 0;
	public float WPRadius = 0.1f;
	public int health = 10;

	void Start () {
 		//Assign the gameobject waypoints when angel spawns
		waypoints[0] = GameObject.Find("T1_2");
		waypoints[1] = GameObject.Find("T2_2");
		waypoints[2] = GameObject.Find("T3_2");
		waypoints[3] = GameObject.Find("T4_2");
		waypoints[4] = GameObject.Find("T5_2");
		waypoints[5] = GameObject.Find("T6_2"); 
	}
	
	void FixedUpdate () {
		//Move the angel twords the next waypoint.
		if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < WPRadius){
			currentWaypoint++;
			//Debug.Log(currentWaypoint);
			if(currentWaypoint >= waypoints.Length){
				Destroy(this.gameObject);
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
	}

	public void Take_Damage(int dmg){
		health -= dmg;
		if(health <= 0){
			Destroy(this.gameObject);
		}
	}
}
