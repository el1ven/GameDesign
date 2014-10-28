using UnityEngine;
using System.Collections;

public class LightningController : MonoBehaviour 
{
	public GameObject explosion;
	void OnParticleCollision(GameObject other) 
	{ 
		if (other.tag == "Monster") 
		{
			Instantiate(explosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other);
	    }
	} 

}
