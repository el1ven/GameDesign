using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
	

}
