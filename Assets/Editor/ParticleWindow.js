

class ParticleWindow extends EditorWindow 
{
    var mScale = 1.0;
    
    @MenuItem ("Custom/particle scale")
    
    static function Init()
    {
        var window : ParticleWindow = EditorWindow.GetWindow( ParticleWindow );
    }
    
    function OnGUI()
    {
        var go = Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel );
		
		var name : String;
		
		if ( go.Length )
			name = go[ 0 ].name;
		else
			name = "select go";
			
        GUILayout.Label ("Object name : " + name, EditorStyles.boldLabel);

        mScale = EditorGUILayout.Slider ("scale : ", mScale, 0.01f, 5.0f);        
        
		if ( GUI.Button( new Rect( 50, 50, 100, 40 ), "set value" ) )
		{
			var ok : boolean = false;
			
			for ( var child : Transform in go[ 0 ].transform )
			{
				if ( child.gameObject.particleEmitter )
				{
					child.gameObject.particleEmitter.minSize *= mScale;
					child.gameObject.particleEmitter.maxSize *= mScale;
					child.gameObject.particleEmitter.worldVelocity *= mScale;
					child.gameObject.particleEmitter.localVelocity *= mScale;
					child.gameObject.particleEmitter.rndVelocity *= mScale;
					child.gameObject.particleEmitter.angularVelocity *= mScale;
					child.gameObject.particleEmitter.rndAngularVelocity *= mScale;
					
					
					ok = true;				
				}
			}
			
			if ( ok )
				go[ 0 ].transform.localScale *= mScale;
				
			if ( ok )
				Debug.Log( "ok!" );
			else
				Debug.Log( "something is wrong!" );
			

		
		}
    }
    
}


