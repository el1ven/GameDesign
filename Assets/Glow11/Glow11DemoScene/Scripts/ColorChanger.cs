using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
 
	private float time=0.0f;
	private float deltaTime = 3.0f;
    Mesh mesh;
    Color[] meshColors;

    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        meshColors = new Color[mesh.vertices.Length];
    }

    // Update is called once per frame
    void FixedUpdate() {

		//time+=Time.timeSinceLevelLoad;
		if (Time.time >= time) 
		      {
			            time += deltaTime;
						float r = Random.Range (0.0f, 1.0f);//= Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad+offset ));
						float g = Random.Range (0.0f, 1.0f);//= Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad*0.45f+offset ));
						float b = Random.Range (0.0f, 1.0f);//= Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad * 1.2f+offset ));	
						Color newColor = new Color (r, g, b);
						for (int i=0; i<meshColors.Length; ++i) 
			            {
								meshColors [i] = newColor;
						}
						mesh.colors = meshColors;
				}
    }
    
}