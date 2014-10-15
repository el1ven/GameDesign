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
	public int life;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;

	public int fireStrength = 1;
	private float ScaleValue= (float)1.0;
	
	void heroBulletRotation(){
		//将世界坐标换算成屏幕坐标
		Vector3 vpos3 = Camera.main.WorldToScreenPoint(shotSpawn.position);
		Vector2 vpos2 = new Vector2 (vpos3.x,vpos3.y);

		//取得鼠标点击的屏幕坐标
		Vector2 input = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

		//取得主角到目标点的向量
		Vector3 v = new Vector3 (vpos2.x-input.x, 0.0f, vpos2.y-input.y);
		Vector3 normal = v.normalized;

		//我们忽略Y轴的向量，把2D向量应用在3D向量中。
		Vector3 targetDirection = new Vector3(-normal.x,0.0f,-normal.z) ;

		shotSpawn.forward = Vector3.Lerp(shotSpawn.forward, targetDirection, 0.5f);


	}

	void Update()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			heroBulletRotation();
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			shot.transform.localScale = new Vector3(ScaleValue,ScaleValue,ScaleValue);
			audio.Play ();
		}
	}

	void FixedUpdate()
	{
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
	public void AddRate()
	{
		if (fireRate > (float)0.1)
		{
			fireRate -= (float)0.05;
	    }
	}
	public void AddStrength()
	{
		fireStrength += 1;
		if(ScaleValue < (float)3.0)
		ScaleValue += (float)0.1;
	}
}
