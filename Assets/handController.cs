using UnityEngine;
using System.Collections;

public class handController : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject bulletExplosion;

	private GameController gameController;
	void Start()
	{
		GameObject gameControllerObject2 = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject2.GetComponent <GameController>();
	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.tag);
		if (other.tag == "bullet") 
		{
			Instantiate(bulletExplosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other.gameObject);		
		}
		if (other.tag == "Player") 
		{
			Instantiate(playerExplosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other.gameObject);
			gameController.GameOver();
		}
	}
}
