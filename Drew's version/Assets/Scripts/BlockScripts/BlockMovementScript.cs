using UnityEngine;
using System.Collections;

public class BlockMovementScript : MonoBehaviour {
	public float blockSpeed;
	private Vector3 temptarget;
	private GameObject target;
	// Use this for initialization
	
	void Start(){
		blockSpeed = 5f;
		target = GameObject.FindWithTag("Player");
		float posZ = target.transform.position.z -.5f;
		float posY = target.transform.position.y -.5f;
		temptarget = new Vector3(0,posY, posZ);
	}
	
	// Update is called once per frame
	void Update () {
	
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
