using UnityEngine;
using System.Collections;

public class BlackHoleController : MonoBehaviour {
	// Use this for initialization
	public float tumble;
	public float pullStrength;
	public float liveTime;

	private float createTime;
	private Vector3 pullDirection;
	void Start () 
	{
		this.rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
		createTime = Time.time;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "enemybullet" || other.tag == "Monster") 
		{
			pullDirection = (this.rigidbody.position - other.rigidbody.position).normalized;
			Debug.Log(pullDirection);
			other.rigidbody.AddForce(pullDirection*pullStrength);
		}
	}
	void Update()
	{
		if ( (Time.time-createTime)> liveTime)
		{
			//Debug.Log(Time.deltaTime);
			Destroy (this.gameObject);
		}
	}
}
