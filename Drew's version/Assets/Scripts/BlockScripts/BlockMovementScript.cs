using UnityEngine;
using System.Collections;

public class BlockMovementScript : MonoBehaviour {
	public float blockSpeed = 10f;

	private GameObject target;
	// Use this for initialization
	void Start(){
		target = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =  Vector3.MoveTowards(transform.position, target.transform.position, blockSpeed * Time.deltaTime);
		//transform.Translate(Vector3.up * blockSpeed * Time.deltaTime);
		
	}
	  void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player"){
			blockSpeed = 0;
		}
		else if (other.gameObject.tag == "block"){
			blockSpeed = 0;
		}
	}
	
}
