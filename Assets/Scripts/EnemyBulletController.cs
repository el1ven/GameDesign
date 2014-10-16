using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject bulletExplosion;
	public int strength;
	private GameObject Hero;
	private heroController gameController;


	void Start()
	{
		Hero = GameObject.FindWithTag ("Player");//找到Hero
		if (Hero != null)
		{
			gameController = Hero.GetComponent <heroController>();
		}		    
	}
	void OnTriggerEnter(Collider other)
	{
			if (other.tag == "Player") 
		    { 
			    gameController.life -= strength;
			    if(gameController.life <= 0)
			    {
				 Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				 Destroy(other.gameObject);
			    }
			    Instantiate(bulletExplosion,this.rigidbody.position,this.rigidbody.rotation);
			    Destroy(gameObject);
			}
		    if (other.tag == "bullet") 
		   {
			Instantiate(bulletExplosion,this.rigidbody.position,this.rigidbody.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		   }
	}
}
