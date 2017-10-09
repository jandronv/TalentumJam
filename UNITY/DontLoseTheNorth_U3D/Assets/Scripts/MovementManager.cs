using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    public GameObject flecha_00;
    public GameObject flecha_01;
    public GameObject flecha_02;
    public GameObject flecha_03;
    public Material blackMaterial;
    public Material[] currentMaterial;

    //0 -> ArribaDcha
    //1 -> AbajoDcha
    //2 -> AbajoIzq
    //3 -> ArribaIzq
    public void InstanceNextTile(GameObject nextTile, int posicion) {

    }

    public void TestMe() {
        Debug.Log("test");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            currentMaterial =
            //flecha_00.GetComponent<MeshRenderer>().materials = blackMaterial;
        } else if (Input.GetKeyDown(KeyCode.A)) {

        } else if (Input.GetKeyDown(KeyCode.S)) {

        } else if (Input.GetKeyDown(KeyCode.D)) {

        }
    }

}
