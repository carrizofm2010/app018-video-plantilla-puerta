using UnityEngine;
using System.Collections;

public class About : MonoBehaviour {

	public GUIStyle styleBox;
	public GUIStyle styleCheckBox;
	public GUIStyle styleCerrar;
	public GUIStyle styleLinkDescarga;
	private Rect cajaBox;
	private Rect cajaCheckBox;
	private Rect cajaCerrar;
	private Rect cajaLinkDescarga;
	private bool flagAbout;
	private bool flagCheckBox;
	public Texture2D textureCheckBoxOn;
	public Texture2D textureCheckBoxOff;
	public Texture2D textureCheckBoxOffIntermedio;
	public Texture2D textureCheckBoxOnIntermedio;
	internal int checkBoxAlmacenado;

	// Use this for initialization
	void Start () {
		flagAbout=true;
		flagCheckBox=true;
	}
	
	// Update is called once per frame
	void Update () {
		this.redimensionarPantalla(Screen.width, Screen.height);
	}
	void OnGUI() {
		if(PlayerPrefs.GetInt("checkBoxAlmacenado",0)==1){
			flagAbout=false;
	 }
		if(flagAbout){
			GUI.Box(cajaBox,"", styleBox);
			if(GUI.Button(cajaCheckBox,AppIUConstantes.CADENA_VACIA,styleCheckBox)){
				this.logicaCheckBox();
			  }
			if(GUI.Button(cajaLinkDescarga,AppIUConstantes.NOMBRE_BOTON_DESCARGA,styleLinkDescarga)){
				Application.OpenURL(AppIUConstantes.LINK_DESCARGA);
			}
			if(GUI.Button(cajaCerrar,AppIUConstantes.CERRAR,styleCerrar)){
				flagAbout=false;
				if(!flagCheckBox){
					PlayerPrefs.SetInt("checkBoxAlmacenado",1);
				}
			   }
			}

    }
	public void logicaCheckBox(){
		if(flagCheckBox){
			styleCheckBox.normal.background=textureCheckBoxOn;
			styleCheckBox.hover.background=textureCheckBoxOnIntermedio;
			flagCheckBox=false;
		}else{
			styleCheckBox.normal.background=textureCheckBoxOff;
			styleCheckBox.hover.background=textureCheckBoxOffIntermedio;
			flagCheckBox=true;
		}
	}
	public void redimensionarPantalla(float width, float height ){
		cajaBox=new Rect(0,0,width,height);
		cajaCheckBox=new Rect(10*width/100,92*height/100,50*width/100,6*height/100);
		cajaLinkDescarga=new Rect(50*width/100-195*width/2000,71*height/100,195*width/1000,39*height/1000);
		cajaCerrar=new Rect(76*width/100,935*height/1000,128*width/1000,39*height/1000);
		styleCerrar.fontSize=(int)(30*Screen.height/1000);
		styleLinkDescarga.fontSize=(int)(30*Screen.height/1000);
	}
}
