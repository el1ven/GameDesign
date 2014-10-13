using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	//destroy the enemy and bullet if they are outside of the boundary
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}

}
