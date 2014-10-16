using UnityEngine;
using System.Collections;

public class BlackHoleCoreController : MonoBehaviour {

	public GameObject enemyExplosion;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "enemybullet" || other.tag == "Monster") 
		{
			Instantiate(enemyExplosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other.gameObject);
		}
	}
}
