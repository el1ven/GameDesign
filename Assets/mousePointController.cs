using UnityEngine;
using System.Collections;

public class mousePointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 e = Input.mousePosition;
		e.z = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 world = Camera.main.ScreenToWorldPoint(e);
	    this.transform.position = world;
	
	}
}
