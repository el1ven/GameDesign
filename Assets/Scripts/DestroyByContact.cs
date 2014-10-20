﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject splitCircle;
	public GameObject SphereRemains;
	public int life;
	public int fireStregth;
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
			     if(this.name=="CubeMonster1(Clone)")
			     gameController.AddRate();
				 if(this.name=="TriangleMonster1(Clone)")
				 gameController.AddStrength();
				 if(this.name=="DoubleCircleMonster")
				 {
					Instantiate(splitCircle,transform.position,transform.rotation);
					Instantiate(splitCircle,transform.position,transform.rotation);
				 }
				 if(this.name=="Sphere M(Clone)")
				 {
					int n=5;
					gameController.life+=1;
					for (; n>0; n--)
					{
						Instantiate(SphereRemains, transform.position, transform.rotation);
					}
				 }
				 Destroy(gameObject);
			}
			Destroy(other.gameObject);
		}
		if (other.tag == "Player")
		{
			if(this.name=="Sphere M(Clone)")
				gameController.life+=1;
			gameController.life -= fireStregth; 
			if(gameController.life <=0)//如果主角生命低下
			{
			 Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			 Destroy(other.gameObject);
			}
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);	
			//gameController.GameOver ();
		}
		if (other.tag == "SphereRemains")
		{
			gameController.life+=1;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
