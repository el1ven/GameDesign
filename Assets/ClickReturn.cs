﻿using UnityEngine;
using System.Collections;

public class ClickReturn : MonoBehaviour {

	void OnClick()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel (1);
	}
}
