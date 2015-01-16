using UnityEngine;
using System.Collections;

public class GuiOptios : MonoBehaviour {
	public GUIStyle styleBox;
	private Rect cajaConfiguracionServidor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.redimensionarPantalla(Screen.width, Screen.height);
	}
	void OnGUI() {
		GUI.Box(cajaConfiguracionServidor,AppIUConstantes.CADENA_VACIA, styleBox);
	}
	public void redimensionarPantalla(float width, float height ){
		cajaConfiguracionServidor=new Rect(0,100*height/100-20*height/100,100*width/100,20*height/100);
	}
}
