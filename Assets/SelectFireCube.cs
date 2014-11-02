using UnityEngine;
using System.Collections;

public class SelectFireCube : MonoBehaviour {
	private GameObject recordObject;
	private OptionParameter recordController;
	void Start()
	{
		recordObject = GameObject.FindGameObjectWithTag ("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();
	}
void OnClick()
	{
		recordController.mode = 0;
		DontDestroyOnLoad (recordObject);
		Application.LoadLevel (2);
	}
}
