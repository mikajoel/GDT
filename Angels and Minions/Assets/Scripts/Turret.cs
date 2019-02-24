using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public AngelController AC;
	public MinionController MC;

	private GameObject target;
	private bool gotTarget;
	public GameObject sparkW, sparkF;


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other);
		if(other.gameObject.tag == "Minion" && target == null){
			target = other.gameObject;
			MC = other.gameObject.GetComponent<MinionController>();
			Targeting();
		}
		if(other.gameObject.tag == "Angel" && target == null){
			target = other.gameObject;
			AC = other.gameObject.GetComponent<AngelController>();
			Targeting();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Minion" && target != null){
			target = null;
		}
		if(other.gameObject.tag == "Angel" && target != null){
			target = null;
		}
	}

	void Targeting(){
		if(target.tag == "Minion"){
			for(int i = 0; i < MC.health; i++){
				MC.Take_Damage(2);
				Instantiate(sparkW, MC.transform.position, Quaternion.identity);
			}
		} else if(target.tag == "Angel"){
			for(int i = 0; i < AC.health; i++){
				AC.Take_Damage(2);
				Instantiate(sparkF, AC.transform.position, Quaternion.identity);
			}
		}
	}
}
