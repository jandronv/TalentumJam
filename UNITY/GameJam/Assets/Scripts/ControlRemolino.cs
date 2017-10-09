using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRemolino : MonoBehaviour {

	public GameObject barco;
	public GameObject barraPrueba;

	public Material rojo;
	public Material verde;

	public Text ganarText;
	public Text cuentaAtrasText;

	public bool ganar;

	public float timeToWin;
	float coordenadaX=0;
	float tiempoBarco;

	void Start () {
		barraPrueba.GetComponent<Renderer> ().material = verde;

		cuentaAtrasText.gameObject.SetActive (true);
		ganarText.gameObject.SetActive (false);
	}
	

	void Update () {


		if (!ganar) 
		{
			coordenadaX = barco.transform.rotation.y * 3;
			transform.position = new Vector3 (coordenadaX, transform.position.y, transform.position.z);
			tiempoBarco = barco.GetComponent<remolinoScript> ().tiempo;

			if (transform.position.x < 1 && transform.position.x > -1 && barraPrueba.GetComponent<Renderer> ().material != verde)
				barraPrueba.GetComponent<Renderer> ().material = verde;
			else if ((transform.position.x > 1 || transform.position.x < -1) && barraPrueba.GetComponent<Renderer> ().material != rojo)
				barraPrueba.GetComponent<Renderer> ().material = rojo;

			if (transform.position.x > 1.5f || transform.position.x < -1.5f) 
			{
				ganarText.text = "Perdiste";
				barco.GetComponent<remolinoScript> ().startRemolino = false;
				cuentaAtrasText.gameObject.SetActive (false);
				ganarText.gameObject.SetActive (true);
				ganar = true;
			}

			if (tiempoBarco >= timeToWin) 
			{
				ganarText.text = "has ganado";
				barco.GetComponent<remolinoScript> ().startRemolino = false;
				cuentaAtrasText.gameObject.SetActive (false);
				ganarText.gameObject.SetActive (true);
				ganar = true;
			} else if(barco.GetComponent<remolinoScript> ().startRemolino){
				cuentaAtrasText.text = (timeToWin-tiempoBarco).ToString ("0");
			}
		}
	}
}
