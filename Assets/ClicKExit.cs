using UnityEngine;
using System.Collections;

public class ClicKExit : MonoBehaviour {
	private GameObject playButton;
	private ClickPlay clickPlay;
	// Use this for initialization
	void Start () {
		playButton = GameObject.FindGameObjectWithTag("Click");
		clickPlay = playButton.GetComponent<ClickPlay> ();
	}

	void OnClick()
	{
		if (clickPlay.push == false) 	
						Application.Quit ();
				else  
						clickPlay.push = false;
	}
}
