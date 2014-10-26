using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject CubeMonster;
	public GameObject TriangleMonster;
	public GameObject SphereMonster;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	public GUIText lifeText;
	public heroController hero;

	public GUIText energyText;
	public int energy;

	public GUIText gameOverText;
	private bool gameOver;

	public GUIText restartText;
	private bool restart;

	void Start ()
	{

		score = 0;
		updateScore ();
		energy = 0;
		updateEnergy ();
		hero.life = 10;
		updateLife ();

		gameOverText.text = "";
		gameOver = false;

		restartText.text = "";
		restart = false;

		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (hero.life <= 0) {
			gameOver = true;
		}
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void updateEnergy(){
		energyText.text = "Energy: " + energy;
	}

	public void AddEnergy(int newEnergyValue){
		energy += newEnergyValue;
		updateEnergy ();
	}

	void updateLife(){
		lifeText.text = "Life: " + hero.life;
	}

	public void AddLife(){
		updateLife ();
	}

	void updateScore(){
		scoreText.text = "Scores:" + score;
	}
	
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}

	public void GameOver(){
		gameOver = true;
		gameOverText.text = "Game Over!";
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			if(gameOver){
				restartText.text = "Press 'R' To Restart";
				restart = true;
				break;
			}

			for (int i = 0; i < hazardCount; i++)
			{   
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (CubeMonster, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < 2; i++)
			{   
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (SphereMonster,spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < hazardCount; i++)
			{   
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (TriangleMonster,spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);


		}
	}

}
