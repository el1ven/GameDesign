#pragma strict
var remains: GameObject;
function Start () {

}

function Update () {   	          
	//if(Input.GetKey(Keycode.space)) //if the sphere moster is killed, then             
	{//do Destory and spown the remains               
		Instantiate(remains, transform.position, transform.rotation);                     
		Destroy(gameObject);              
	}
}