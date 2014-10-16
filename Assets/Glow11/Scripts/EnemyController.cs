using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;
	public float speed;

	private GameObject Hero;
	private float nextCheck = 0;
	void Start()
	{
		Hero = GameObject.FindGameObjectWithTag("Player");
		if (Hero)
			rigidbody.velocity = (Hero.rigidbody.position - this.rigidbody.position).normalized * speed;//设置初速度和方向
		else
			rigidbody.velocity = transform.forward * speed;
	}
	void Update()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		if (Time.time > nextCheck) 
		{
			nextCheck += (float)3.0;
			if(Hero)
			rigidbody.velocity = (Hero.rigidbody.position - this.rigidbody.position).normalized * speed;
		}
	}
}
