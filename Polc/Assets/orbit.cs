using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour {

	public float speed = 0.1f;
	
	void Update () {
		this.transform.RotateAround(Vector3.zero, 
			Vector3.right, speed);
	}
}
