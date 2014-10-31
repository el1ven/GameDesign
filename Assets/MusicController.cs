using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	private GameObject recordObject;
	private OptionParameter recordController;
	private UISlider uiSlider;
	// Use this for initialization
	void Start () 
	{
		recordObject = GameObject.FindGameObjectWithTag ("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();
		uiSlider = this.gameObject.GetComponent<UISlider>();
	}
	void Update()
	{
		recordController.musicVolume = uiSlider.value;
	}
}
