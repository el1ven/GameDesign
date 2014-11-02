using UnityEngine;
using System.Collections;

public class head : MonoBehaviour {

	public Texture2D breathe1;
	public Texture2D breathe2;
	public Texture2D breathe3;
	public Texture2D breathe4;
	public Material Body;

	private float startTime = 0.0f;
	public  float deltaTime;
	// Use this for initialization
	void Start () {
		Body.mainTexture = breathe3;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Time.time > startTime)
		{
			startTime += deltaTime;

			if (Body.mainTexture == breathe3)
				Body.mainTexture = breathe2;
			else if (Body.mainTexture == breathe2)
				Body.mainTexture = breathe1;
			else if (Body.mainTexture == breathe1)
				Body.mainTexture = breathe4;
			else if (Body.mainTexture == breathe4)
				Body.mainTexture = breathe3;

		}
		Debug.Log (Body.mainTexture.ToString ());
	}
}
