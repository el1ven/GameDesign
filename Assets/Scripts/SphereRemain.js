#pragma strict

var explosion:GameObject;
var playerExplosion:GameObject ;
function Start () {
	yield WaitForSeconds(3.0); 
	Instantiate(explosion, transform.position, transform.rotation);
	var SpCollider = GetComponent(SphereCollider) as SphereCollider;
	//if(SpCollider.radius !=0.5f)           
	//	Destroy(gameObject); 
	SpCollider.radius = 5.0f; 
	yield WaitForSeconds(1.0);            
	Destroy(gameObject); 

}

function Update () {

}