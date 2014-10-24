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

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		score = 0;
		updateScore ();
		energy = 0;
		updateEnergy ();
		hero.life = 10;
		updateLife ();
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

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
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
