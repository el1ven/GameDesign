using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour 
{
	public int ShiledNum;

	private GameController gameController;
	private heroController hero;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		gameController = gameControllerObject.GetComponent <GameController>();

		GameObject heroControllerObject = GameObject.FindWithTag("Player");

		hero = heroControllerObject.GetComponent <heroController>();

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Monster") 
		{
			ShiledNum -- ;
			gameController.AddShield(-1);
		    Destroy (other.gameObject);
		}
		if (ShiledNum <= 0) 
		{
			hero.SetShield();
			Destroy (this.gameObject);
		}
	}
}
