using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	GetPosition();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GetPosition(){
		float posX = Random.Range(-7.5f,7.5f);
		float posY = Random.Range(-4.6f,6.6f);
		if(posX > -.6 && posX < .6){
			GetPosition();
		}
		else if(posY > -.65 && posY < .65){
			GetPosition();
		}
		else{
			transform.Translate(posX,posY,0);
		}
	}
}