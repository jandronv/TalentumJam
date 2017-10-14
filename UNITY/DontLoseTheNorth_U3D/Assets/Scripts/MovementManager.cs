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




    //StartCoroutine(MoveOverSeconds (gameObject, new Vector3(0.0f, 10f, 0f), 5f));

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
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    //0 -> ArribaDcha
    //1 -> AbajoDcha
    //2 -> AbajoIzq
    //3 -> ArribaIzq
    public void InstanceNextTile(GameObject paco, int posicion) {
        GameObject newTile = Instantiate<GameObject>(ChooseRandomTile()) as GameObject;
        newTile.transform.SetParent(tileHolder.transform);
        switch (posicion) {
            case 0: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x + 15, newTile.transform.position.y, newTile.transform.position.z);

                    float startTime = Time.time;
                    float journeyLength = Vector3.Distance(newTile.transform.position, currentTile.transform.position);
                    float distCovered = (Time.time - startTime) * movSpeed;
                    float fracJourney = distCovered / journeyLength;

                    newTile.transform.position = Vector3.Lerp(newTile.transform.position, currentTile.transform.position, fracJourney);


                    //newTile.transform.Translate(currentTile.transform.position);
                    /*Vector3.Lerp(newTile.transform.position, currentTile.transform.position, movSpeed)*/;
                    //currentTile.transform.Translate(new Vector3(currentTile.transform.position.x - 15, currentTile.transform.position.y, currentTile.transform.position.z));
                    //GameObject currentAux = currentTile;
                    //Destroy(currentTile);
                    //currentTile = newTile;
                    break;
                }
            case 1: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x + 15, newTile.transform.position.y, newTile.transform.position.z);
                    break;
                }
            case 2: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x, newTile.transform.position.y, newTile.transform.position.z - 15);
                    break;
                }
            case 3: {
                    newTile.transform.position = new Vector3(newTile.transform.position.x - 15, newTile.transform.position.y, newTile.transform.position.z);
                    break;
                }

        }
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
            flecha_01.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_02.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_03.GetComponent<MeshRenderer>().materials = currentMaterial;
            //Instanciar siguiente tile
            InstanceNextTile(null, 0);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            //Cambio de materiales
            flecha_00.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_01.GetComponent<MeshRenderer>().materials = newMaterial;
            flecha_02.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_03.GetComponent<MeshRenderer>().materials = currentMaterial;
            //Instanciar siguiente tile
            InstanceNextTile(null, 1);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            //Cambio de materiales
            flecha_00.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_01.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_02.GetComponent<MeshRenderer>().materials = newMaterial;
            flecha_03.GetComponent<MeshRenderer>().materials = currentMaterial;
            //Instanciar siguiente tile
            InstanceNextTile(null, 2);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            //Cambio de materiales
            flecha_00.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_01.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_02.GetComponent<MeshRenderer>().materials = currentMaterial;
            flecha_03.GetComponent<MeshRenderer>().materials = newMaterial;
            //Instanciar siguiente tile
            InstanceNextTile(null, 3);
        }
    }

}
