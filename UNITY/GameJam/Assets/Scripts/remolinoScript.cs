using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remolinoScript : MonoBehaviour {

	public bool startRemolino;

	public float sensi;
	public float rotacionBarco;
	public float tiempo;

	public int aleatorio;

	void Start()
	{
		aleatorio = Random.Range (0, 10);
		if (aleatorio < 5)
			rotacionBarco = rotacionBarco;
		else
			rotacionBarco = rotacionBarco * -1;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			startRemolino = true;
		}

		if (startRemolino) 
		{
			tiempo += Time.deltaTime;
			transform.Rotate (0, rotacionBarco, 0);
		}

		if (Input.GetKeyDown (KeyCode.D)) 
		{
			Debug.Log ("funciona");
			transform.Rotate (0, -sensi, 0);
		}
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			Debug.Log ("funcionaA");
			transform.Rotate (0, sensi, 0);
		}
	}
}
