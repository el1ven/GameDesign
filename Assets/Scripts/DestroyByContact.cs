using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int life;
	private heroController gameController;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("Player");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <heroController>();
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bullet") 
		{
			life -= gameController.fireStrength;
			if(life <= 0)
			{
			 Instantiate(explosion, transform.position, transform.rotation);
			 Destroy(gameObject);
		     if(this.name=="CubeMonster1(Clone)")
		     gameController.AddRate();
			 if(this.name=="TriangleMonster1(Clone)")
			 gameController.AddStrength();
			}
			Destroy(other.gameObject);
		}
		if (other.tag == "Player")
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
			//gameController.GameOver ();
		}
	}
}
