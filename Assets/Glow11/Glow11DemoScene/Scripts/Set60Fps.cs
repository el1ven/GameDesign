using UnityEngine;
using System.Collections;

public class Set60Fps : MonoBehaviour
{
	public GameObject hero;
	private Vector3 offset;
    // Use this for initialization
    void Start ()
    {
		offset = transform.position + new Vector3 (0.0f, 10.0f, 0.0f);
    }
	void LateUpdate()
	{
		if (hero)
			transform.position = hero.transform.position + offset;
		else
		    transform.position = new Vector3 (0.0f, 10.0f, 0.0f);
	}
    
}
