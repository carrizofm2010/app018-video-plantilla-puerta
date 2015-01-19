using UnityEngine;
using System.Collections;

public class GuiOptios : MonoBehaviour {
	public GUIStyle styleBox;
	public GUIStyle styleBotonFlash;
	public GUIStyle styleBotonAbout;
	private Rect cajaConfiguracionServidor;
	private Rect cajaBotonFlash;
	private Rect cajaBotonAbout;
	private bool flagScreem;
	private bool flagExit;
	VideoPlaybackUIEventHandler handler;
	// Use this for initialization
	void Start () {
		flagScreem=false;
		flagExit=false;
		handler = GameObject.FindObjectOfType(typeof(VideoPlaybackUIEventHandler)) as VideoPlaybackUIEventHandler;
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
			if(GUI.Button(cajaBotonFlash,AppIUConstantes.CADENA_VACIA,styleBotonFlash)){
				CameraDevice.Instance.SetFlashTorchMode(true);
//				if (handler != null)
//				{
//					handler.View.mCameraFlashSettings.Enable(true);
//					CameraDevice.Instance.SetFlashTorchMode(true);
//				}
			}
			if(GUI.Button(cajaBotonAbout,AppIUConstantes.CADENA_VACIA,styleBotonAbout)){
				CameraDevice.Instance.SetFlashTorchMode(false);
//				if (handler != null)
//				{
//					handler.View.mCameraFlashSettings.Enable(false);
//				}
			}
		}

	}
	
	public void redimensionarPantalla(float width, float height ){
		cajaConfiguracionServidor=new Rect(0,100*height/100-20*height/100,100*width/100,20*height/100);
		cajaBotonFlash=new Rect(10*width/100,100*height/100-19*height/100,30*width/100,30*width/100);
		cajaBotonAbout=new Rect(100*width/100-30*width/100-10*width/100,100*height/100-19*height/100,30*width/100,30*width/100);
	}
}
