using UnityEngine;
using System.Collections;

public class ScreenShakeController : MonoBehaviour {
	
	private float shakeTime = 0.0f;
	private float fps= 20.0f;
	private float frameTime =0.0f;
	private float delta = 0.005f;
	public  Camera cam ;
	public static bool isshakeCamera =false;
	// Use this for initialization
	void Start ()
	{
		shakeTime = 2.0f;
		fps= 20.0f;
		frameTime =0.03f;
		delta = 0.005f;
		isshakeCamera=false;
	}
	// Update is called once per frame
	void Update ()
	{
		if (isshakeCamera)
		{
			if(shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if(shakeTime <= 0)
				{
					cam.rect = new Rect(0.0f,0.0f,1.0f,1.0f);
					isshakeCamera =false;
					shakeTime = 1.0f;
					fps= 20.0f;
					frameTime =0.03f;
					delta =0.005f;
				}
				else
				{
					frameTime += Time.deltaTime;
					if(frameTime > 1.0 / fps)
					{
						frameTime = 0;
						cam.rect = new Rect(delta * ( -1.0f + 2.0f * Random.value), delta * ( -1.0f + 2.0f * Random.value), 1.0f, 1.0f);
					}
				}
			}
		}
	}
}