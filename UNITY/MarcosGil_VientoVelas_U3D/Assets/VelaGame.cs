using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelaGame : MonoBehaviour {
	public bool gameOn;

	public bool storm;
	public bool sails;

	public float progress;
	public float damage;

	public float targetProgress;
	public float targetDamage;

	public float speedProgress;
	public float speedDamage;

	public float stormTimeMin;
	public float stormTimeMax;

	public float calmTimeMin;
	public float calmTimeMax;

	public float timeCurrent;
	public float timeTarget;


	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOn) {
			if (Input.GetKeyDown (KeyCode.W)) {
				sails = true;
				OnSailsOpen ();
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				sails = false;
				OnSailsClose ();
			}

			timeCurrent += Time.deltaTime;
			if (timeCurrent >= timeTarget) {
				storm = !storm;
				timeCurrent = 0;
				damage = 0;
				if (storm) {
					timeTarget = Random.Range (stormTimeMin, stormTimeMax);
					OnStormStart ();
				} else {
					timeTarget = Random.Range (calmTimeMin, calmTimeMax);
					OnStormEnd ();
				}

			
			}

			if (storm && sails) {
				damage += Time.deltaTime * speedDamage;
			}

			if (!storm && sails) {
				progress += Time.deltaTime * speedProgress;
			}

			if (damage >= targetDamage) {
				OnGameEnd (false);
			}
			if (progress >= targetProgress) {
				OnGameEnd (true);
			}


			gameObject.transform.position = new Vector3 (0, 0, progress);
			gameObject.transform.localScale = new Vector3 (1 - damage, 1 - damage, 1 - damage);

		}
	}

	void OnStormStart(){
		GameObject.Find("Lluvia").GetComponent<Renderer>().enabled=true;
	}

	void OnStormEnd(){
		GameObject.Find("Lluvia").GetComponent<Renderer>().enabled=false;
	}
	void OnSailsOpen(){
		GameObject.Find("Velas").GetComponent<Renderer>().enabled=true;
	}
	void OnSailsClose(){
		GameObject.Find("Velas").GetComponent<Renderer>().enabled=false;

	}

	void StartGame(){
		gameOn = true;
	}

	void OnGameEnd(bool win){
		gameOn = false;
	}


}
