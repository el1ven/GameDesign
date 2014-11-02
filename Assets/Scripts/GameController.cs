using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject CubeMonster;
	public GameObject TriangleMonster;
	public GameObject SphereMonster;
	public GameObject firstBoss; 
	public int firstBossScore;
	public Vector3 spawnValues;

	public Texture GUI_Heart;
	public Texture GUI_Score;
	public Texture GUI_HighScore;
	public Texture GUI_Energybar;
	public Texture GUI_Energyframe;
	public Texture GUI_Blackhole00;
	public Texture GUI_Blackhole01;
	public Texture GUI_Lightning00;
	public Texture GUI_Lightning01;
	public Texture GUI_Shield00;
	public Texture GUI_Shield01;

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

	public bool pause = false;
	
	private GameObject PausePanel;
	void Start ()
	{
		PausePanel = GameObject.FindGameObjectWithTag("PausePanel");
		PausePanel.SetActive (false);
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
			PausePanel.SetActive(true);
			            pause = true;
						Time.timeScale = 0.0f;		
				} 
		else if (Input.GetKeyDown (KeyCode.Escape) && pause == true) {
			            PausePanel.SetActive(false);
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
	void OnGUI()
	{
		//Vector3 WindowPos = //need to decide the position
		print ("OnGUI called");
		if(energy < hero.blackNum){
			GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2-128,128,128),GUI_Blackhole00);
		}
		else{GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2-128,128,128),GUI_Blackhole01);}
		if(energy < hero.lightNum){
			GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2,128,128),GUI_Lightning00);
		}
		else{GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2,128,128),GUI_Lightning01);}
		if(energy < hero.shiledNum){
			GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2+128,128,128),GUI_Shield00);
		}
		else{GUI.DrawTexture(new Rect (Screen.width-150,Screen.height/2+128,128,128),GUI_Shield01);}
		
		GUI.DrawTexture (new Rect(Screen.width-150-50,Screen.height/2-128+250,60,-256/100*energy),GUI_Energybar);
		GUI.DrawTexture (new Rect(Screen.width-150-32,Screen.height/2-75,32,256),GUI_Energyframe);
		
		for(int i=0; i<hero.life; i++){
			GUI.DrawTexture (new Rect (Screen.width/2-125+25*i,50,25,25), GUI_Heart);
		}
		GUI.DrawTexture (new Rect (25,15,128,64), GUI_Score);
		GUI.color = Color.yellow;
		GUI.skin.label.fontSize = 30;
		GUI.Label (new Rect (50, 50, 128, 64), ""+score);
		GUI.DrawTexture (new Rect (Screen.width-200, 15, 128, 50), GUI_HighScore);
		GUI.skin.label.fontSize = 30;
	}

}
