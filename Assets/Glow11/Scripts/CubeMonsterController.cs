using UnityEngine;
using System.Collections;

public class CubeMonsterController : MonoBehaviour {

	public float speed;//移动速度
	public float tumble;//旋转速度
	public float RushDistance;//冲刺最小距离
	public float RushWaitTime;//冲刺等待时间
	public float RushSpeed;//冲刺速度

	private Vector3 RecordPath;
	private GameObject Hero;
	private int accumulateTime = -1;
	// Use this for initialization
	void Start ()//初始化
	{
		//获取英雄位置
		Hero = GameObject.FindWithTag ("Player");//找到Hero
		if (Hero)
		rigidbody.velocity = (Hero.rigidbody.position - this.rigidbody.position).normalized * speed;//设置初速度和方向
		else
		rigidbody.velocity = transform.forward * speed;
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;//设置旋转
		StartCoroutine (CheckRush ());
	}
	IEnumerator CheckRush()//轮询检查
	{
	  while (true) {
						yield return new WaitForSeconds ((float)1.0);
						if (this == null || Hero == null)//如果物体已被摧毁，返回
								return true;
						if(accumulateTime >= 0) 
			             {//如果时间积累到可以冲刺，直接一波冲过去
								accumulateTime++;
								if (accumulateTime == RushWaitTime) 
				                {
										this.rigidbody.velocity = RecordPath * RushSpeed;
										accumulateTime = -1;
					                    yield return new WaitForSeconds((float)1.0);//冲俩秒
								}
								//Debug.Log (accumulateTime);
						 }
			           else
			           {
						  float distance = Vector3.Distance (this.rigidbody.position, Hero.rigidbody.position);//计算与Hero的距离
						  if (distance < RushDistance) 
			              {     //如果在冲刺范围内
								//画出冲刺路径，并等待
					            
								this.rigidbody.velocity = (Hero.rigidbody.position - this.rigidbody.position).normalized * 0;
					            RecordPath = (Hero.rigidbody.position - this.rigidbody.position).normalized;
								accumulateTime = 0;
						  }
			           }
				}
	}
}
