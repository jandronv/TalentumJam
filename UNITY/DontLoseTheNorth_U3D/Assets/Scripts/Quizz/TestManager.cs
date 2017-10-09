using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    public TestWrapper testWrapper;
    private string pathResources = "Assets/Resources/";
    private string nombreTest = "Quizz";
    private string extension = ".json";

    public Text textEnunciado;
    public Button buttonOpcion0;
    public Button buttonOpcion1;

    private string textoAcierto = "¡HAS ACERTADO!";
    private string textoError = "¡HAS FALLADO!";
    public GameObject panelConfirmacion;
    public Text textConfirmacion;
    public Text textExplicacion;
    public Button buttonConfirmacion;


    void Start () {
        //if (testWrapper.tests != null) {
        //    SerializeMe(testWrapper, true);
        //}
        DeserializeMe();
        InstanciarPregunta(SeleccionarPreguntaAleatoria());
    }

    void OnApplicationQuit() {
        testWrapper.tests = null;    
    }
    public Test SeleccionarPreguntaAleatoria() {
        int idPregunta = UnityEngine.Random.Range(0, testWrapper.tests.Length);
        return testWrapper.tests[idPregunta];
    }

    public void InstanciarPregunta(Test test) {
        textEnunciado.text = test.enunciado;
        textExplicacion.text = test.explicacion;
        buttonOpcion0.GetComponentInChildren<Text>().text = test.opciones[0];
        buttonOpcion1.GetComponentInChildren<Text>().text = test.opciones[1];
        buttonOpcion0.onClick.AddListener(() => ComprobarRespuesta(test.resultados[0]));
        buttonOpcion1.onClick.AddListener(() => ComprobarRespuesta(test.resultados[1]));
    }

    public void ComprobarRespuesta(bool resultado) {
        buttonOpcion0.interactable = false;
        buttonOpcion1.interactable = false;
        panelConfirmacion.SetActive(true);
        if (resultado) {
            textConfirmacion.text = textoAcierto;
        } else {
            textConfirmacion.text = textoError;
        }
        buttonConfirmacion.GetComponentInChildren<Text>().text = "OK";
        buttonConfirmacion.onClick.AddListener(() => CerrarPanel());
    }

    public void CerrarPanel() {
        buttonOpcion0.interactable = true;
        buttonOpcion1.interactable = true;
        panelConfirmacion.SetActive(false);
    }

    public void SerializeMe(TestWrapper testObject, bool saveToFile = false) {
        string testJson = JsonUtility.ToJson(testObject);
        Debug.Log(testJson);
        if(saveToFile)
            System.IO.File.WriteAllText(pathResources + nombreTest + extension, testJson);
    }

    public void DeserializeMe() {
        string testJson = Resources.Load(nombreTest).ToString();
        testWrapper = JsonUtility.FromJson<TestWrapper>(testJson);
    }
}
