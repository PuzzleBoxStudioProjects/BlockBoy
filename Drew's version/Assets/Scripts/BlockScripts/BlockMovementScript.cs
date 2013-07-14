using UnityEngine;
using System.Collections;

public class BlockMovementScript : MonoBehaviour {
	public float blockSpeed;
	private Vector3 temptarget;
	private  GameObject target;
	

	// Use this for initialization
	
	void Start(){
		
		blockSpeed = 5f;
		target = GameObject.FindWithTag("Player");
		Vector3 temptarget = new Vector3(0, target.transform.position.y, target.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position =  Vector3.MoveTowards(transform.position, temptarget, blockSpeed * Time.deltaTime);
		
		
	}
	  void OnCollisionStay(Collision other) {
		
		if (other.gameObject.tag == "ground"){
			this.gameObject.tag = "blocks";
			blockSpeed = 0;
			BlockTrigger.create = true;
			print("hit ground");			
			
		}
		else if (other.gameObject.tag == "block"){
			this.gameObject.tag = "blocks";
			blockSpeed = 0;
			BlockTrigger.create = true;
			print ("hit block");
		}
		
	}
	
	//Debug.DrawRay(originOfRay, directionOfRay * distanceToCast, Color.blue);
}
