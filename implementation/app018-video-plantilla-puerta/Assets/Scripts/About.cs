using UnityEngine;
using System.Collections;

public class About : MonoBehaviour {
	
	//public GUIStyle styleLabelIkaros;
	public GUIStyle styleBox;
	private Rect Caja;
	private bool flagScreem;
	private bool flagExit;
	// Use this for initialization
	void Start () {
		flagScreem=false;
		flagExit=false;
		
	}
	
	// Update is called once per frame
	void Update () {
	Caja=new Rect(0,0,Screen.width,Screen.height);
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(flagExit){
				flagScreem=false;
				flagExit=false;
		    	//Screen.orientation = ScreenOrientation.Landscape;
				
			}else{
				Application.Quit();
			}
			
			
		}
		if(Input.GetKeyDown(KeyCode.Menu))
		{
			flagScreem=true;
			flagExit=true;
		}
		
	}
	void OnGUI() {
		
		if(flagScreem){
			//Screen.orientation = ScreenOrientation.Portrait;
			GUI.Box(Caja,"", styleBox);
		}

		
    }
}
