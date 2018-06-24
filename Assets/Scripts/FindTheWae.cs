using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheWae : MonoBehaviour {

    public float speed;
    public float movementDistance;
    public float hmmTime;

    private Vector3 p;

	void Start () {
        p = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void Update () {
        float deltaX;
        float deltaZ;
        if (p.x >= transform.position.x){
            deltaX = p.x - transform.position.x;
        }else{
            deltaX = transform.position.x - p.x;
        }

        if (p.z >= transform.position.z){
            deltaZ = p.z - transform.position.z;
        }else{
            deltaZ = transform.position.z - p.z;
        }

        if (deltaX < 1f && deltaZ < 1f){
            //Debug.Log("No Wae.");
            Invoke("ShowDaWae", hmmTime);
        }
	}

    void FixedUpdate(){
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, p, step);
    }

    void ShowDaWae(){
        float moveHorizontal = Random.Range(-movementDistance, movementDistance);
        float moveVertical = Random.Range(-movementDistance, movementDistance);
        Vector3 movement = new Vector3(p.x + moveHorizontal, transform.position.y, p.z + moveVertical);
        p = movement;
        //Debug.Log("New Wae: " + p);
        transform.LookAt(p);
    }

}
