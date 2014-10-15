using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	//destroy the enemy and bullet if they are outside of the boundary
	void OnTriggerExit(Collider other){
		if (other.tag == "bullet") 
		    {
			  Destroy (other.gameObject);
			}
		if (other.tag == "enemybullet") {
			Destroy (other.gameObject);
		}
	}
}
