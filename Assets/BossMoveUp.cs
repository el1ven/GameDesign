using UnityEngine;
using System.Collections;

public class BossMoveUp : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("path1"), "time", 10));
		
	}
	
	// Update is called once per frame
	void Update () {	
	}
}