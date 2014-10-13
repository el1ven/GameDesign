using UnityEngine;
using System.Collections;

[System.Serializable]//make the boundary be known by Unity3D
public class Boundary{
	//set the game boundary
	public float minX, maxX, minZ, maxZ;
}

public class heroController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;

	void Update(){
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		}
	}

	void FixedUpdate(){
		//get the input from keyboard
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//make the movement speed
		this.rigidbody.velocity =  new Vector3 (moveHorizontal,0.0f,moveVertical) * speed;

		//make the movement boundary
		this.rigidbody.position = new Vector3 (
			Mathf.Clamp(this.rigidbody.position.x, boundary.minX, boundary.maxX),//set the boundary of Player
			0.0f,
			Mathf.Clamp(this.rigidbody.position.z, boundary.minZ, boundary.maxZ)
			);

		//make the slip effect
		this.rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, this.rigidbody.velocity.x * -tilt);//slip effect
		
	}

	

}
