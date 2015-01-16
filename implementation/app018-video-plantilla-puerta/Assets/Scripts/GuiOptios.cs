using UnityEngine;
using System.Collections;

public class GuiOptios : MonoBehaviour {
	public GUIStyle styleBox;
	private Rect cajaConfiguracionServidor;
	private bool flagScreem;
	private bool flagExit;
	// Use this for initialization
	void Start () {
		flagScreem=false;
		flagExit=false;
	}	
	// Update is called once per frame
	void Update () {
		this.redimensionarPantalla(Screen.width, Screen.height);
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(flagExit){
				flagScreem=false;
				flagExit=false;
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
			GUI.Box(cajaConfiguracionServidor,AppIUConstantes.CADENA_VACIA, styleBox);
		}

	}
	public void redimensionarPantalla(float width, float height ){
		cajaConfiguracionServidor=new Rect(0,100*height/100-20*height/100,100*width/100,20*height/100);
	}
}
