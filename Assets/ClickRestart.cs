using UnityEngine;
using System.Collections;

public class ClickRestart : MonoBehaviour {

	void OnClick()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel (2);
	}
}
