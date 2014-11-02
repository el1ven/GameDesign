using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {

	public GameObject hitEffect;
	public GameObject snakeBurnEffect;
	public float speed;
	public int snakeLife;
	
	private GameObject hero;
	private float nextCheck = 0.2f;
	void Start () 
	{
		hero = GameObject.FindGameObjectWithTag("Player");
		//iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("path1"), "time", 20));
	}
	void Update () 
	{
		if (Time.time > nextCheck) 
		{
			nextCheck += (float)1.0f;
			if(hero){
			    transform.LookAt(-hero.rigidbody.position + this.rigidbody.position);
			    rigidbody.velocity = (hero.rigidbody.position - this.rigidbody.position).normalized * speed;
			}
		}
	}
}
