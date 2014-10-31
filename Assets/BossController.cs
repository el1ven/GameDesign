using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	// Use this for initialization

	public GameObject hitEffect;
	public GameObject bossBurnEffect;
	public float speed;
	public int bossLife;

	private GameObject hero;
	private Animator anim;
	private float nextCheck = 1.0f;
	void Start () 
	{
		hero = GameObject.FindGameObjectWithTag("Player");
	    anim = GetComponent<Animator>();
		anim.SetBool("Attack", false);
		anim.SetBool("wave", false);
		anim.SetBool("slap", false);
	}
	void Update () 
	{
       if (this.bossLife <=150 &&speed == 1.0f) //阶段1
		        {
			       speed = 1.5f;
			       anim.SetBool ("Attack", true);
			       anim.SetBool("wave", true);
				}
	   if (this.bossLife <= 100 && speed==1.5f)//阶段2
		        {
			      speed = 2.0f;
			      this.transform.Rotate(new Vector3(0,1,0),1.0f);
				}
	   if (this.bossLife <= 50 && speed == 2.0f)//阶段3 
		        {
			      this.transform.Rotate(new Vector3(0,1,0),0.0f);
			      anim.SetBool("slap",true);
				}
		if (Time.time > nextCheck) 
		{
			nextCheck += (float)1.0;
			if(hero)
			  rigidbody.velocity = (hero.rigidbody.position - this.rigidbody.position).normalized * speed;
		}
	}
}
