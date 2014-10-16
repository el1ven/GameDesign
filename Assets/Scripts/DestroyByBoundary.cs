using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	public GameObject bulletExplosion;
	//destroy the enemy and bullet if they are outside of the boundary
	void OnTriggerExit(Collider other){
		if (other.tag == "bullet") 
		    {
			  Destroy (other.gameObject);
			}
		if (other.tag == "enemybullet") {
			Instantiate(bulletExplosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy (other.gameObject);
		}
	}
}
