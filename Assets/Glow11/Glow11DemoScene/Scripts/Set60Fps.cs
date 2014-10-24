using UnityEngine;
using System.Collections;

public class Set60Fps : MonoBehaviour
{
	public GameObject hero;
	private Vector3 offset;
    // Use this for initialization
    void Start ()
    {
		offset = transform.position;
    }
	void LateUpdate()
	{
		transform.position = hero.transform.position + offset;
	}
    
}
