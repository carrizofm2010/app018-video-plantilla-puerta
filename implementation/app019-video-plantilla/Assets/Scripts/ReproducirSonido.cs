using UnityEngine;
using System.Collections;

public class ReproducirSonido : MonoBehaviour {
	public AudioClip soundFireworks;
	// Use this for initialization
	void Start () {
	 //playSoundAmbient();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	/*Reproducir sonido*/
	public void playSoundFireworks(){
		  audio.PlayOneShot(soundFireworks);
	}


}
