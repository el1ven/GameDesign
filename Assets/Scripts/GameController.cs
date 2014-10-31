using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject CubeMonster;
	public GameObject TriangleMonster;
	public GameObject SphereMonster;
	public GameObject firstBoss; 
	public int firstBossScore;
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

	public GUIText shieldText;
	private int shield;

	public GUIText gameOverText;
	private bool gameOver;

    public GUIText restartText;
	private bool restart;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
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
	}
	void Update ()
	{
		if (hero.life <= 0) 
	   {
			gameOver = true;
		}
		if (gameOver)
		 {
			if (Input.GetKeyDown (KeyCode.R))
			  {
				Application.LoadLevel (Application.loadedLevel);
			  }
		 }
	}
	public void GameOver()
   {
		 gameOver = true;
		 gameOverText.text = "Game Over!";
		 restartText.text ="Please Press 'R' to restart";
   }

    void updateShiled(){
		shieldText.text = "Shield: " + shield;
		}
	void updateEnergy(){
		energyText.text = "Energy: " + energy;
	}
	void updateLife(){
		lifeText.text = "Life: " + hero.life;
	}
	void updateScore(){
		scoreText.text = "Scores:" + score;
	}
   public void AddShield(int shieldValue)
	{
		shield += shieldValue;
		updateShiled ();
	}
   public void AddEnergy(int newEnergyValue){
		energy += newEnergyValue;
		updateEnergy ();
	}
   public void AddLife(){
		updateLife ();
	}
   public void AddScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			hazardCount +=1;
			for (int i = 0; i < hazardCount; i++)
			{   
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (CubeMonster, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i <hazardCount; i++)
			{   
				Vector3 spawnPosition = new Vector3 (spawnValues.x,spawnValues.y, Random.Range(-spawnValues.z,spawnValues.z));
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (SphereMonster,spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < hazardCount; i++)
			{   
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y, -spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				Instantiate (TriangleMonster,spawnPosition,spawnRotation);
			}
			if( this.score >= firstBossScore)//如果分数够了出大boss干翻
			{
				firstBossScore += 30000;
				 Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.8f, spawnValues.z);
				 Quaternion spawnRotation = new Quaternion(0,180,0,0); 
				 Instantiate(firstBoss,spawnPosition,spawnRotation);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
