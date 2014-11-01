using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	private GameObject recordObject;
	private OptionParameter recordController;
	private UISlider uiSlider;
	private GameObject scene;
	// Use this for initialization
	void Start () 
	{
		recordObject = GameObject.FindGameObjectWithTag ("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();
		uiSlider = this.gameObject.GetComponent<UISlider>();
		scene = GameObject.FindGameObjectWithTag ("menu");
	}
	void Update()
	{
		recordController.musicVolume = uiSlider.value;
		scene.audio.volume = uiSlider.value;
		//this.audio.volume = uiSlider.value;
	}
}
