using UnityEngine;
using System.Collections.Generic;

public class PlayerPhysics : MonoBehaviour {
	// public variables.
		
	public static PlayerPhysics instance;
	
	
	
	
	public int 			showDistance;
	public float 		speed,
						rotation,
						drag,
						highScore;
	public static float	distance;	
	public Vector3		direction,
						position;
		
	//private variables 
	//private HUDScript 	wrapper;
	
	
	public enum PlayerState
	{
		isAlive,
		dead		
	}
	public PlayerState state {get; set;}
	
	
	void Awake(){
		instance = this;
		//wrapper = GetComponent<HUDScript>();
	}
								
	// Use this for initialization
	void Start () {
		speed  		= 3;
		rotation 	= 0;
		drag 		= .03f;
		state = PlayerState.isAlive;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMoto();
		
	}
	
	void PlayerMoto(){
		if( state == PlayerState.isAlive){
			this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);			
		
		if(Input.GetAxis("Horizontal") != 0)		{
			
			var axis = Input.GetAxis("Horizontal") * Time.deltaTime * speed;	
			this.gameObject.transform.Translate(Vector3.right * axis);	
			HUDScript.oil -= 1/15;
		}
			
		if(this.gameObject.transform.position.x <= -8){
			this.gameObject.transform.position = new Vector3(-8,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		 	HUDScript.fuel -= 1/30;
			}
			
		else if (this.gameObject.transform.position.x >= 8){
			this.gameObject.transform.position = new Vector3(8,this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			HUDScript.fuel -= 1/30;
			}
		}
	}

	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Fueltank(Clone)"){
			print ("Weve collided w/ " + other.gameObject.name);
			other.gameObject.transform.position = new Vector3(0,0,this.transform.position.z - 10);
			HUDScript.instance.AddFuel(20);
		}
		
		if(other.gameObject.name == "Oilcan(Clone)"){
			print ("Weve collided w/ " + other.gameObject.name);
			other.gameObject.transform.position = new Vector3(0,0,this.transform.position.z - 10);
			HUDScript.instance.AddOil(10);
		}
	}
	
	
	
	void OnGUI(){
		
		
	}
}
