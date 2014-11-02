using UnityEngine;
using System.Collections;

public class ClickReturn : MonoBehaviour {

	void OnClick()
	{
		Application.LoadLevel (0);
			Time.timeScale = 1.0f;
	}
}
