using UnityEngine;
using System.Collections;

public class LegDestroyController : MonoBehaviour {
    
	public int legLife;
	// Use this for initialization
	void Start () 
	{
	  
	}
	
	// Update is called once per frame
	void Update () 
	{
	   if (legLife <= 0 && this.name=="Bone001")
		{

			Destroy(GameObject.Find("Box009"));
			/*
			Destroy(GameObject.Find("Box010"));
			Destroy(GameObject.Find("Box011"));
			Destroy(GameObject.Find("Box012"));
			Destroy(GameObject.Find("Box013"));
			Destroy(GameObject.Find("Box014"));
			Destroy(GameObject.Find("Box015"));
			Destroy(GameObject.Find("Box016"));
			Destroy(GameObject.Find("Cylinder0"));
			Destroy(GameObject.Find("Cylinder1"));
			Destroy(GameObject.Find("Cylinder2"));
			Destroy(GameObject.Find("Pyramid3"));
			Destroy(GameObject.Find("Pyramid4"));
			*/
			//Destroy(this.gameObject);
		}
	}
}
