using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	public GameObject _cursor1, _cursor2; //Grid cursor gameobjects
	public GameObject turret; //Turret assets

	//Grid: 20(width) x 18(height)
	public static float gridPosV1, gridPosV2, gridPosH1, gridPosH2; //Value of grid cell the cursors are positioned on

	void Start () {
		//Place the cursors at starting position
		_cursor1.transform.position = new Vector3(0.5f, 0.5f, 0f);
		_cursor2.transform.position = new Vector3(0.5f, -0.5f, 0f);
		//Set grid value == their position
		gridPosV1 = 0.5f;
		gridPosH1 = 0.5f;

		gridPosV2 = -0.5f;
		gridPosH2 = 0.5f;
	}
	
	void Update () {
		//Movement of the cursors
		_cursor1.transform.position = new Vector3(gridPosH1, gridPosV1, 0f);
		_cursor2.transform.position = new Vector3(gridPosH2, gridPosV2, 0f);
		//Player 1 Controls
		if(Input.GetKeyDown(KeyCode.W) && gridPosV1 < 8.5f){
			gridPosV1 += 1f;
		} else if(Input.GetKeyDown(KeyCode.S) && gridPosV1 > 0.5f){
			gridPosV1 -= 1f;
		} else if(Input.GetKeyDown(KeyCode.A) && gridPosH1 > -15.5f){
			gridPosH1 -= 1f;
		} else if(Input.GetKeyDown(KeyCode.D) && gridPosH1 < 9.5f){
			gridPosH1 += 1f;
		}
		//Player 2 Controls
		if(Input.GetKeyDown(KeyCode.UpArrow) && gridPosV2 < -0.5f){
			gridPosV2 += 1f;
		} else if(Input.GetKeyDown(KeyCode.DownArrow) && gridPosV2 > -8.5f){
			gridPosV2 -= 1f;
		} else if(Input.GetKeyDown(KeyCode.LeftArrow) && gridPosH2 > -15.5f){
			gridPosH2 -= 1f;
		} else if(Input.GetKeyDown(KeyCode.RightArrow) && gridPosH2 < 9.5f){
			gridPosH2 += 1f;
		}

		//Place Turrets
		if(Input.GetKeyDown(KeyCode.E)){
			Instantiate(turret, _cursor1.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown(KeyCode.Return)){
			Instantiate(turret, _cursor2.transform.position, Quaternion.identity);
		}
	}
}
