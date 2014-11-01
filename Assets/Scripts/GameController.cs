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

	private GameObject recordObject;
	private OptionParameter recordController;

	private bool pause = false;

	void Start ()
	{

		recordObject = GameObject.FindGameObjectWithTag("recordObject");
		recordController = recordObject.GetComponent<OptionParameter>();

		if (recordController.mode == 0) 
		{//简单模式
			firstBossScore = 10000000;
			this.audio.volume = recordController.musicVolume;
		}
		if (recordController.mode == 1) 
		{//困难模式
			firstBossScore = 10000;
			this.audio.volume = recordController.musicVolume;
		}
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
		if (Input.GetKeyDown (KeyCode.Escape) && pause == false) {
			            pause = true;
						Time.timeScale = 0.0f;		
				} 
		else if (Input.GetKeyDown (KeyCode.Escape) && pause == true) {
			            pause = false;
			            Time.timeScale = 1.0f;
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
