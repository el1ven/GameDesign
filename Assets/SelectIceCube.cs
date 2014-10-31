using UnityEngine;
using System.Collections;

public class SelectIceCube : MonoBehaviour {

	private GameObject recordObject;
	private OptionParameter recordController;
	void Start()
	{
		recordObject = GameObject.FindGameObjectWithTag ("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();
	}
	void OnClick()
	{
		recordController.mode = 1;
		DontDestroyOnLoad (recordObject);
		Application.LoadLevel (1);
	}
}
