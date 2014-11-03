using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour {
     
	private BossController bossController;
	private GameController gameController;
	// Use this for initialization
	void Start () 
 	{
		GameObject gameControllerObject2 = GameObject.FindWithTag("Boss");
		bossController = gameControllerObject2.GetComponent <BossController>();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();
		//Debug.Log (gameController);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bullet") 
		{
			bossController.bossLife -=1;
			Instantiate(bossController.hitEffect,other.rigidbody.position,other.rigidbody.rotation);
			Destroy(other.gameObject);
			if(bossController.bossLife <=0)
			{
				gameController.AddEnergy(100);
				gameController.AddScore(100000);
			    Instantiate(bossController.bossBurnEffect,bossController.rigidbody.position,bossController.rigidbody.rotation);
				Destroy (bossController.gameObject);
			}
		}
		if (other.tag == "Player") 
		{
			Destroy (other.gameObject);
			gameController.GameOver();
		}
	}
}
