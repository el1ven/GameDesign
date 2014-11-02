using UnityEngine;
using System.Collections;

public class ClickResume : MonoBehaviour {
   
	private GameController gameController;
	private GameObject PausePanel;
	void Start()
	{
		PausePanel = GameObject.FindGameObjectWithTag("PausePanel");
		GameObject gameObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameObject.GetComponent<GameController> ();
	}
	void OnClick()
	{

		gameController.pause = false;
		Time.timeScale = 1.0f;
		PausePanel.SetActive (false);
	}
}
