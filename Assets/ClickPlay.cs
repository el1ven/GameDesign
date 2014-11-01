using UnityEngine;
using System.Collections;

public class ClickPlay : MonoBehaviour {
     public bool push;
	// Use this for initialization
	void Start () {
		push = false;
	}
	
	void OnClick()
	{
	  if(push ==false)
		push = true;
	}
}
