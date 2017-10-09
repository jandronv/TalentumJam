using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TestWrapper {
    [SerializeField]
    public Test[] tests;
}

[Serializable]
public class Test {
    [SerializeField]
    public int idPregunta;
    [SerializeField]
    public string enunciado;
    [SerializeField]
    public string[] opciones;
    [SerializeField]
    public bool[] resultados;
    [SerializeField]
    public string explicacion;


    public override string ToString() {
        return "IdPregunta: " + this.idPregunta + "\nTitulo" + this.enunciado + "\nOpciones: " + this.opciones[0] + " - " + this.opciones[1] + "\nResultados: " + this.resultados[0] + " - " + this.resultados[1] + "\nExplicación: " + this.explicacion;
    }
}
