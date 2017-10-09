using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Tooltip("Tamaño del mapa que se va a crear")]
	public int TamMapa = 0;

	[Tooltip("Numero de eventos en el que el jugador va a tener que interactuar.")]
	public int NumEventoJuegos = 0;


	[Tooltip("Prefabs para la creación del mapa")]
	public List<GameObject> TiposEventos;

	private GameObject[,] Mapa;

	GameObject ground;

	// Use this for initi(alization
	void Start () {

		ground = new GameObject("Mapa");

		if (TamMapa == 0 || NumEventoJuegos == 0 || TiposEventos == null)
		{
			Debug.LogError("Inicializa el tamaño de los eventos!!");
		}
		else
		{
			Mapa = new GameObject[TamMapa, TamMapa];

			//Creamos al azar el inicio y final
			//Inicio
			int xIni = Random.Range(0, 3);
			int yIni = Random.Range(0,3);
			GameObject g = Instantiate(TiposEventos[1], new Vector3(xIni, 0, yIni), Quaternion.identity);
			g.transform.parent = ground.transform;
			//final
			int xFin = Random.Range((TamMapa - 3), (TamMapa -1));
			int yFin = Random.Range((TamMapa - 3), (TamMapa - 1));


			GameObject h = Instantiate(TiposEventos[1], new Vector3(xFin, 0, yFin), Quaternion.identity);
			h.transform.parent = ground.transform;

			//Inicializamos el evento entre agua y eventos
			for (int i = 0;i < TamMapa ; i++)
			{
				for (int j = 0; j < TamMapa; j++)
				{

					if ((i == xIni && j == yIni) || (i == xFin && j == yFin)) {


					}
					else
					{

						int evento = Random.Range(0, 2);

						if (evento == 1 && NumEventoJuegos > 0)
						{
							NumEventoJuegos--;

							GameObject k = Instantiate(TiposEventos[0], new Vector3(i, 0, j), Quaternion.identity);
							k.transform.parent = ground.transform;
							Mapa[i, j] = k;
						}
						else
						{
							GameObject l = Instantiate(TiposEventos[2], new Vector3(i, 0, j), Quaternion.identity);
							l.transform.parent = ground.transform;
							Mapa[i, j] = l;
						}
					}

				}
			}
			

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
