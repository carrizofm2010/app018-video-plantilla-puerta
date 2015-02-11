using UnityEngine;
using System.Collections;

public class GuiOptios : MonoBehaviour {
	private Rect rectBeginArea;
	private Rect cajaContacto;
	private Rect cajaFacebook;
	private Rect cajaYouTube;
	private Rect cajaGmail;
	public GUIStyle styleBeginArea;
	public GUIStyle styleBoton;
	public GUIStyle styleContacto;
	public GUIStyle styleFacebook;
	public GUIStyle styleYouTube;
	public GUIStyle styleGmail;
	private bool flagScreem;
	private bool flagExit;
	private bool flagFlash;
	private bool flagContacto;
	private bool flagAbout;
	private string estadoFlash;
	private Rect cajaAbout;
	private Rect cajaLinkDescarga;
	public GUIStyle styleAbout;
	public GUIStyle styleLinkDescarga;
	// Use this for initialization
	void Start () {
		flagScreem=false;
		flagExit=false;
		flagFlash=true;
		flagContacto=false;
		flagAbout=false;
		estadoFlash=AppIUConstantes.FLASH_ON;
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
			if(flagContacto){
				flagContacto=false;
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
			GUILayout.BeginArea(rectBeginArea,styleBeginArea);
				if(GUILayout.Button(estadoFlash,styleBoton,GUILayout.Width(80*Screen.width/100),GUILayout.Height(10*Screen.height/100))){
					if(flagFlash){
					    CameraDevice.Instance.SetFlashTorchMode(flagFlash);
						flagScreem=false;
						flagFlash=false;
					    estadoFlash=AppIUConstantes.FLASH_OFF;
					}else{
						CameraDevice.Instance.SetFlashTorchMode(flagFlash);
						flagScreem=false;
						flagFlash=true;
					    estadoFlash=AppIUConstantes.FLASH_ON;
				}
				}
				if(GUILayout.Button(AppIUConstantes.AUTOFOCUS,styleBoton,GUILayout.Width(80*Screen.width/100),GUILayout.Height(10*Screen.height/100))){
					CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
					flagScreem=false;
				}
				if(GUILayout.Button(AppIUConstantes.ABOUT,styleBoton,GUILayout.Width(80*Screen.width/100),GUILayout.Height(10*Screen.height/100))){
					flagAbout=true;
					flagScreem=false;
					flagExit=true;
				}
				if(GUILayout.Button(AppIUConstantes.CONTACTO,styleBoton,GUILayout.Width(80*Screen.width/100),GUILayout.Height(10*Screen.height/100))){
					flagContacto=true;
					flagScreem=false;
				    flagExit=true;
				}
			GUILayout.EndArea();
		}
		if(flagContacto){
			GUI.Box(cajaContacto,"", styleContacto);
			if(GUI.Button(cajaGmail,AppIUConstantes.GMAIL,styleGmail)){
				Application.OpenURL(AppIUConstantes.DIRECCION_GMAIL);
			}
			if(GUI.Button(cajaFacebook,AppIUConstantes.FACEBOOK,styleFacebook)){
				Application.OpenURL(AppIUConstantes.FACEBOOK);
			}
			if(GUI.Button(cajaYouTube,AppIUConstantes.NOMBRE_CUENTA_YOUTUBE,styleYouTube)){
				Application.OpenURL(AppIUConstantes.DIRECCION_YOUTUBE);
			}
		}
		if(flagAbout){
			GUI.Box(cajaAbout,"", styleAbout);
			if(GUI.Button(cajaLinkDescarga,AppIUConstantes.NOMBRE_BOTON_DESCARGA,styleLinkDescarga)){
				Application.OpenURL(AppIUConstantes.LINK_DESCARGA);
			}

		}

	}

	public void redimensionarPantalla(float width, float height ){
		rectBeginArea=new Rect(10*width/100,100*height/100-39*height/100,90*width/100-10*width/100,41*height/100);
		cajaGmail=new Rect(27*width/100,39*height/100,36*width/100,4*height/100); 
		cajaFacebook=new Rect(27*width/100,47*height/100,59*width/100,4*height/100);
		cajaYouTube=new Rect(27*width/100,55*height/100,21*width/100,4*height/100); 
		cajaContacto=new Rect(0,0,Screen.width,Screen.height);
		styleBoton.fontSize=(int)(5*Screen.height/100);
		styleFacebook.fontSize=(int)(26f*Screen.height/1000);
		styleYouTube.fontSize=(int)(26*Screen.height/1000);
		styleGmail.fontSize=(int)(26*Screen.height/1000);
		cajaAbout=new Rect(0,0,width,height);
		cajaLinkDescarga=new Rect(50*width/100-195*width/2000,71*height/100,195*width/1000,39*height/1000);
		styleLinkDescarga.fontSize=(int)(30*Screen.height/1000);
	}
}
