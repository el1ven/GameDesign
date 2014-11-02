using UnityEngine;
using System.Collections;

public class movie : MonoBehaviour {
	public MovieTexture mp;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		renderer.material.mainTexture=mp;
		mp.loop=false;
		mp.Play();
		music.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>51){
			Application.LoadLevel("Menu");
		}
	}
}
