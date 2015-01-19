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
	private bool flagFlash;
	private bool flagAbout;
	public Texture2D botonFlashOn;
	public Texture2D botonFlashOff;
	public GUIStyle styleAbout;
	private Rect cajaAbout;
	// Use this for initialization
	void Start () {
		flagScreem=true;//cambiar
		flagExit=false;
		flagFlash=true;
		flagAbout=false;
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
			if(flagAbout){
				flagAbout=false;
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
				if(flagFlash){
					CameraDevice.Instance.SetFlashTorchMode(true);
					StartCoroutine(ocultarPantallaOn());
				}else{
					CameraDevice.Instance.SetFlashTorchMode(false);
					StartCoroutine(ocultarPantallaOff());
				}
			}
			if(GUI.Button(cajaBotonAbout,AppIUConstantes.CADENA_VACIA,styleBotonAbout)){
				flagAbout=true;
				flagScreem=false;
			}

		}
		if(flagAbout){
			GUI.Box(cajaAbout,"", styleAbout);
		}

	}
	public IEnumerator ocultarPantallaOn(){
		styleBotonFlash.normal.background=botonFlashOn;
		yield return new WaitForSeconds(AppIUConstantes.TIEMPO_ESPERA);
		flagScreem=false;
		flagFlash=false;
	}
	public IEnumerator ocultarPantallaOff(){
		styleBotonFlash.normal.background=botonFlashOff;
		yield return new WaitForSeconds(AppIUConstantes.TIEMPO_ESPERA);
		flagScreem=false;
		flagFlash=true;
	}
	public void redimensionarPantalla(float width, float height ){
		cajaConfiguracionServidor=new Rect(0,100*height/100-20*height/100,100*width/100,20*height/100);
		cajaBotonFlash=new Rect(10*width/100,100*height/100-19*height/100,30*width/100,30*width/100);
		cajaBotonAbout=new Rect(100*width/100-30*width/100-10*width/100,100*height/100-19*height/100,30*width/100,30*width/100);
		cajaAbout=new Rect(0,0,Screen.width,Screen.height);
	}
}
