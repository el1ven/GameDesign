using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject CubeMonster;
	public GameObject TriangleMonster;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
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
				Instantiate (TriangleMonster,spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
