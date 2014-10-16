using UnityEngine;
using System.Collections;

public class Set60Fps : MonoBehaviour
{
	public GameObject hero;
    // Use this for initialization
    void Start ()
    {
        Application.targetFrameRate = 60;
    }
	void Update ()
	{
		this.transform.position = new Vector3 (hero.transform.position.x, 10, hero.transform.position.z);
	}
    
}
