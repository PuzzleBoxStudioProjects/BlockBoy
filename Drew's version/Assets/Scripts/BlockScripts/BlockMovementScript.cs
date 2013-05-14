using UnityEngine;
using System.Collections;

public class BlockMovementScript : MonoBehaviour {
	public float blockSpeed = 5f;

	private GameObject target;
	// Use this for initialization
	void Start(){
		target = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
	var fwd = transform.TransformDirection(target.transform.position.x,0,0);
		if(Physics.Raycast(transform.position, fwd,10)){
			print ("hit");
		}
		transform.position =  Vector3.MoveTowards(transform.position, target.transform.position, blockSpeed * Time.deltaTime);
		
		
	}
	  void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player"){
			blockSpeed = 0;
		}
		else if (other.gameObject.tag == "block"){
			blockSpeed = 0;
		}
	}
	
	//Debug.DrawRay(originOfRay, directionOfRay * distanceToCast, Color.blue);
}
