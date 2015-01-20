using UnityEngine;
using System.Collections;

public class JuegosArtificiales : MonoBehaviour {
	private string mensajeBorrar="";
	private  VideoPlaybackBehaviour video;
	public Transform prefabExplosion1;
	public Transform prefabExplosion2;
	public Transform prefabExplosion3;
	public Transform prefabExplosion4;
	public Transform prefabExplosion5;
	public Transform prefabExplosion6;
	private Transform InstanciaExplosion;
	public Transform marcadorPadre;
	private bool flagExplosion1;
	private bool flagExplosion2;
	private bool flagExplosion3;
	private bool flagExplosion4;
	private bool flagExplosion5;
	private bool flagExplosion6;
	// Use this for initialization
	void Start () {
		this.iniciarExplosion();
		video = GetComponentInChildren<VideoPlaybackBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	
		if (video.CurrentState == VideoPlayerHelper.MediaState.ERROR)
		{
						 mensajeBorrar="ERROR";
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.NOT_READY)
		{
			mensajeBorrar="NOT_READY";
		
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.PAUSED)
		{
						 mensajeBorrar="PAUSED";
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
		{
						 mensajeBorrar="PLAYING";
			this.iniciarExplosion();

		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING_FULLSCREEN)
		{
						 mensajeBorrar="PLAYING_FULLSCREEN";
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.REACHED_END)
		{
			mensajeBorrar="REACHED_END";
			if(flagExplosion1){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion1,0));
				flagExplosion1=false;
			}
			if(flagExplosion2){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion2,1));
				flagExplosion2=false;
			}
			if(flagExplosion3){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion3,2));
				flagExplosion3=false;
			}
			if(flagExplosion4){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion4,3));
				flagExplosion4=false;
			}
			if(flagExplosion5){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion5,4));
				flagExplosion5=false;
			}
			if(flagExplosion6){
				StartCoroutine(tiempoEsperaExplosion(prefabExplosion6,4));
				flagExplosion6=false;
			}
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.READY)
		{
						 mensajeBorrar="READY";
		}
		if (video.CurrentState == VideoPlayerHelper.MediaState.STOPPED)
		{
						 mensajeBorrar="STOPPED";
		}
	}
	void OnGUI() {
//		GUI.Label(new Rect(Screen.width-200,Screen.height-100, 200, 100), mensajeBorrar);
	}
	public void iniciarExplosion(){
		flagExplosion1=true;
		flagExplosion2=true;
		flagExplosion3=true;
		flagExplosion4=true;
		flagExplosion5=true;
		flagExplosion6=true;
	}
	public IEnumerator tiempoEsperaExplosion(Transform prefabExplosion,float tiempoExpera){
		yield return new WaitForSeconds(tiempoExpera);
		this.explotar(prefabExplosion,InstanciaExplosion,marcadorPadre);
	}
	public void explotar(Transform prefabExplosion,Transform elemento, Transform marcadorPadre) {
		elemento= Instantiate(prefabExplosion,prefabExplosion.transform.position,prefabExplosion.rotation) as Transform;
		elemento.parent=marcadorPadre;
		elemento.transform.localScale=new Vector3(prefabExplosion.transform.localScale.x, prefabExplosion.transform.localScale.y, prefabExplosion.transform.localScale.z);
		elemento.transform.localPosition=new Vector3(prefabExplosion.transform.position.x,prefabExplosion.transform.position.y,prefabExplosion.transform.position.z);
		Destroy(elemento.gameObject,4);
		
	}
}
