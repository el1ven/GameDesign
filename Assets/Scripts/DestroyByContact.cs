using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject SphereRemains;
	//public int life;
	public int fireStregth;
	private heroController gameController;
	
	private GameController gamePanel;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("Player");
		GameObject gameControllerObject2 = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <heroController>();
		}
		if (gameControllerObject2 != null)
		{
			gamePanel = gameControllerObject2.GetComponent <GameController>();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bullet") 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			if(this.name=="CubeMonster1(Clone)")
			    {
			        //gameController.AddRate();
					gamePanel.AddScore(100);
					gamePanel.AddEnergy(1);
					//gameController.life-=1;
					gamePanel.AddLife();
				    Destroy(gameObject);
				}
				 if(this.name=="TriangleMonster1(Clone)")
			    {
				    gameController.AddStrength();
					gamePanel.AddScore(200);
					gamePanel.AddEnergy(2);
					gamePanel.AddLife();
				    Destroy(gameObject);
				}
				 if(this.name=="Sphere M(Clone)")
				 {
					int n=3;
					gamePanel.AddLife();
					gamePanel.AddScore(300);
					gamePanel.AddEnergy(3);
					for (; n>0; n--)
					{
						Vector3 v = transform.position + new Vector3(Mathf.Sin(n*1.0f/3)*2.5f,0.0f,Mathf.Sin(n*1.0f/10)*1.0f);
						Instantiate(SphereRemains, v, transform.rotation);
					}
				    Destroy(gameObject);
				 }
			  if(this.name =="SphereRemain(Clone)")
			    {
				  gamePanel.AddLife();
				  gamePanel.AddEnergy(1);
				  Destroy(gameObject);
			    }
		       	  Destroy(other.gameObject);
		  }
		else if (other.tag == "Player")
		{

			gameController.life -= 1;
			gamePanel.AddLife();
			if(gameController.life <=0)//如果主角生命低下
			{
			    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			    Destroy(other.gameObject);
				gamePanel.GameOver();
			}
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);	
			//gameController.GameOver ();
	   }
	  }
}
