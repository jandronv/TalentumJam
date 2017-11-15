using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    public GameObject[] idleTiles;

    public GameObject tileHolder;
    public GameObject currentTile;
    public GameObject flecha_00;
    public GameObject flecha_01;
    public GameObject flecha_02;
    public GameObject flecha_03;
    public Material blackMaterial;
    private Material[] currentMaterial;
    private Material[] newMaterial;
    public float movSpeed = 5.0f;

    void Awake() {
        newMaterial = new Material[1];
        newMaterial[0] = blackMaterial;
        currentMaterial = flecha_00.GetComponent<MeshRenderer>().materials;
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 endPosition, float speed) {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != endPosition) {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, endPosition, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds) {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds) {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeOverSeconds(GameObject objectToFade, float seconds) {
        float elapsedTime = 0;
        while (elapsedTime < seconds) {
            var material = objectToFade.GetComponent<Renderer>().material;
            var color = material.color;
            material.color = new Color(color.r, color.g, color.b, color.a - (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator WaitSomeSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    //0 -> ArribaDcha. N
    //1 -> AbajoDcha. E
    //2 -> AbajoIzq. S
    //3 -> ArribaIzq. O
    public void InstanceNextTile(GameObject nextTile, int posicion) {
        //TODO: ahora es ChooseRandomTile, más tarde será una leida del mapa
        GameObject newTile = Instantiate<GameObject>(ChooseRandomTile()) as GameObject;
        Vector3 fadePosition = new Vector3();
        newTile.transform.SetParent(tileHolder.transform);
        switch (posicion) {
            case 0: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x + 15, newTile.transform.position.y, newTile.transform.position.z);                    
                    fadePosition = new Vector3(currentTile.transform.position.x-5, currentTile.transform.position.y, currentTile.transform.position.z);
                    break;
                }
            case 1: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x, newTile.transform.position.y, newTile.transform.position.z+15);
                    fadePosition = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, currentTile.transform.position.z-5);
                    break;
                }
            case 2: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x - 15, newTile.transform.position.y, newTile.transform.position.z);
                    fadePosition = new Vector3(currentTile.transform.position.x + 5, currentTile.transform.position.y, currentTile.transform.position.z);
                    break;
                }
            case 3: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x, newTile.transform.position.y, newTile.transform.position.z-15);
                    fadePosition = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, currentTile.transform.position.z+5);
                    break;
                }
        }
        StartCoroutine(MoveOverSeconds(newTile, currentTile.transform.position, movSpeed));
        StartCoroutine(MoveOverSeconds(currentTile, fadePosition, movSpeed));
        //StartCoroutine(FadeOverSeconds(currentTile, movSpeed));
        Destroy(currentTile, 0.5f);
        currentTile = new GameObject();
        currentTile = newTile;
        StartCoroutine(WaitSomeSeconds(3f));
        flecha_00.GetComponent<MeshRenderer>().materials = currentMaterial;
        flecha_01.GetComponent<MeshRenderer>().materials = currentMaterial;
        flecha_02.GetComponent<MeshRenderer>().materials = currentMaterial;
        flecha_03.GetComponent<MeshRenderer>().materials = currentMaterial;
    }

    private void Update() {
        InputControl();
    }

    public GameObject ChooseRandomTile() {
        int chosenTile = Random.Range(0, idleTiles.Length);
        return idleTiles[chosenTile];
    }

    public void InputControl() {
        if (Input.GetKeyDown(KeyCode.W)) {
            //Cambio de materiales
            flecha_00.GetComponent<MeshRenderer>().materials = newMaterial;
            //Instanciar siguiente tile
            InstanceNextTile(null, 0);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            flecha_01.GetComponent<MeshRenderer>().materials = newMaterial;
            InstanceNextTile(null, 1);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            flecha_02.GetComponent<MeshRenderer>().materials = newMaterial;
            InstanceNextTile(null, 2);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            flecha_03.GetComponent<MeshRenderer>().materials = newMaterial;
            InstanceNextTile(null, 3);
        }
        
    }

}
