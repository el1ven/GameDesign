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
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform trailSpawn;
	public float fireRate;
	public float nextFire;

	public GameObject blackHole;
	public GameObject shield;
	public GameObject lightning;
    
	public GameObject degradeEffect;
	public GameObject evolutionEffect;
	public GameObject lightningEffect;
	public GameObject shieldEffect;
	public GameObject blackHoleEffect;
	public GameObject trailEffect;
	
	public int fireStrength = 1;
	public int blackNum;
	public int shiledNum;
	public int lightNum;
	private GameController gameController;

	private float ScaleValue= (float)1.0;
	private bool haveShiled = false;

	public Texture2D textureLevel1;
	public Texture2D textureLevel2;
	public Texture2D textureLevel3;
	public Texture2D textureLevel4;

	public int levelUpNum;
	public int levelEnergy = 100;

	public int curLevel = 1;

	private GameObject recordObject;
	private OptionParameter recordController;

	void Start()
	{

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		this.transform.Rotate(new Vector3(0,1,0), 90.0f);

		gameController = gameControllerObject.GetComponent <GameController>();

		recordObject = GameObject.FindGameObjectWithTag("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();

		//Debug.Log (this.renderer.material.mainTexture);
		//renderer.material.mainTextureScale = new Vector2(2.0f,2.0f);

		//renderer.material.SetTexture("Element 1",textureLevel1);

		this.audio.volume = recordController.effectVolume;

	}
	
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
		Vector3 targetDirection = new Vector3(-normal.x,0.0f,-normal.z);
		shotSpawn.forward = Vector3.Lerp(shotSpawn.forward, targetDirection, 0.5f);
		shotSpawn2.forward = Vector3.Lerp(shotSpawn2.forward, targetDirection, 0.5f);
		shotSpawn3.forward = Vector3.Lerp(shotSpawn3.forward, targetDirection, 0.5f);
	}

	void heroRotation(){
		//hero rotation according to the mouse
		Vector3 e = Input.mousePosition;
		e.z = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 world = Camera.main.ScreenToWorldPoint(e);
		transform.LookAt(world); //物体朝向鼠标
	}

	void Update()
	{

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			heroBulletRotation();
			heroRotation();
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			if(curLevel>=2)
			{
			Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
			fireRate =(float) 0.08;
			}
			if(curLevel>=3)
			{
				Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
				fireRate =(float) 0.06;
			}
			if(curLevel>=4)
			{
				fireStrength = 2;
			}
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

		if (Input.GetAxis ("Horizontal")!=0.0f || Input.GetAxis("Vertical")!=0.0f) 
		{
			Instantiate (trailEffect, trailSpawn.position, trailSpawn.rotation);		
		}

		heroRotation();
       
		if (Input.GetKeyDown("2") &&gameController.energy >= blackNum) 
		{
			gameController.AddEnergy(-blackNum);
			Instantiate(blackHole,this.rigidbody.position,this.rigidbody.rotation);
			Instantiate(blackHoleEffect,this.rigidbody.position,this.rigidbody.rotation);
		}
		if(Input.GetKeyDown("4") && gameController.energy >= shiledNum && haveShiled == false)
		{
			gameController.AddEnergy(-shiledNum);

			Instantiate(shield,this.rigidbody.position,this.rigidbody.rotation).name = "shield";
			GameObject.Find("shield").transform.parent = this.transform;
			GameObject.Find("shield").transform.localScale = new Vector3(3.0f,3.0f,3.0f);
			haveShiled = true;
			Instantiate(shieldEffect,this.rigidbody.position,this.rigidbody.rotation);
			gameController.AddShield(2);
		}
		if (Input.GetKeyDown ("3") && gameController.energy >= lightNum) 
		{
			gameController.AddEnergy(-lightNum);
			Instantiate(lightning,this.rigidbody.position,this.rigidbody.rotation);
			Instantiate(lightningEffect,this.rigidbody.position,this.rigidbody.rotation);
		}
		if (Input.GetKeyDown ("1") && gameController.energy >= levelUpNum) 
		{
			curLevel++;
			gameController.energy -= levelUpNum;
			switch(curLevel)
			{
			  case 1:
				levelEnergy = 100;
				Instantiate(evolutionEffect,this.rigidbody.position,this.rigidbody.rotation);
				renderer.materials [1].mainTexture = textureLevel1;
				break;
			  case 2:
				//renderer.material.SetTexture("Element 1",textureLevel1);
				levelEnergy =200;
				Instantiate(evolutionEffect,this.rigidbody.position,this.rigidbody.rotation);
				 renderer.materials [1].mainTexture = textureLevel2;
			     //renderer.material.mainTexture = textureLevel2;
			     break;
			 case 3:
				levelEnergy = 300;
				 Instantiate(evolutionEffect,this.rigidbody.position,this.rigidbody.rotation);
				 renderer.materials [1].mainTexture = textureLevel3;
				 //renderer.material.mainTexture =textureLevel3;
			     break;
			 case 4:
				levelEnergy = 400;
				Instantiate(evolutionEffect,this.rigidbody.position,this.rigidbody.rotation);
				renderer.materials [1].mainTexture = textureLevel4;
				break;
			default:
				break;
			}
		}

	}
	public void AddRate()
	{
		/*if (fireRate > (float)0.1)
		{
			fireRate -= (float)0.05;
	    }*/
	}
	public void AddStrength()
	{
		/*fireStrength += 1;
		if(ScaleValue < (float)3.0)
		ScaleValue += (float)0.1;*/
	}
	public void DeGrade()
	{
		curLevel--;
		switch (curLevel) 
		{
		case 1:
			levelEnergy = 100;
			Instantiate(degradeEffect,this.rigidbody.position,this.rigidbody.rotation);
			renderer.materials [1].mainTexture = textureLevel1;
			break;
		case 2:
			levelEnergy = 200;
			//renderer.material.SetTexture("Element 1",textureLevel1);
			Instantiate(degradeEffect,this.rigidbody.position,this.rigidbody.rotation);
			renderer.materials [1].mainTexture = textureLevel2;
			//renderer.material.mainTexture = textureLevel2;
			break;
		case 3:
			levelEnergy = 300;
			Instantiate(degradeEffect,this.rigidbody.position,this.rigidbody.rotation);
			renderer.materials [1].mainTexture = textureLevel3;
			//renderer.material.mainTexture =textureLevel3;
			break;
		case 4:
			levelEnergy = 400;
			Instantiate(degradeEffect,this.rigidbody.position,this.rigidbody.rotation);
			renderer.materials [1].mainTexture = textureLevel4;
			break;
		default:
			break;	
		}
	}
	public void SetShield()
	{
		haveShiled = false;
	}
}
