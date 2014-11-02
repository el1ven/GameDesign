using UnityEngine;
using System.Collections;

public class SnakeBodyController : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject bulletExplosion;
	
	private SnakeController snakeController;
	private GameController gameController;
	private heroController hero;
	
	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject2 = GameObject.FindWithTag("Snake");
		snakeController = gameControllerObject2.GetComponent <SnakeController>();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();
		GameObject gameControllerObject3 = GameObject.FindWithTag ("Player");
		hero = gameControllerObject3.GetComponent <heroController>();
		//Debug.Log (gameController);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bullet") 
		{
			snakeController.snakeLife -=1;
			Instantiate(snakeController.hitEffect,other.rigidbody.position,other.rigidbody.rotation);
			Instantiate(bulletExplosion,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other.gameObject);
			if(snakeController.snakeLife <=0)
			{
				gameController.AddEnergy(20);
				gameController.AddScore(400);
				Instantiate(snakeController.snakeBurnEffect,snakeController.rigidbody.position,snakeController.rigidbody.rotation);
				Destroy (snakeController.gameObject);
			}
		}
		else if (other.tag == "Player") 
		{
			hero.life -= 1;
			gameController.AddLife();
			if(hero.life <= 0){
				Instantiate(playerExplosion,other.rigidbody.position,other.rigidbody.rotation);
				Destroy (other.gameObject);
			}
		}
	}
}
