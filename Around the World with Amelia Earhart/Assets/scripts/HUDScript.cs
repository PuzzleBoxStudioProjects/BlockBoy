using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	public Transform 	oilPin;
	public Transform 	fuelPin;
	public GameObject 	oilPressureLight;
	public GameObject 	fuelPressureLight;
	
	public static HUDScript instance;
	public PlayerPhysics.PlayerState currentState;
	
	public float 		fuelPressure,
						oilPressure,
						showDistance,
						highScore;
	public static float fuel,
						distance,
						oil;

    public float angle;

	// Use this for initialization
	
	void Awake(){
		instance = this;
		
	}
	
	
	void Start () {
		fuel     	= 100;
		oil 		= 100;
		distance 	= 0;
		highScore  	= 0;
		this.currentState = PlayerPhysics.instance.state;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGuages();
		PressureCheck();
		DistanceControl();
		EmptyGauges();
		fuelPressure = (int)fuel;
		oilPressure  = (int)oil;
		showDistance = (int)distance;
	}
		
	void PressureCheck(){
		if(fuel <= 0 || oil <= 0){
			PlayerPhysics.instance.state = PlayerPhysics.PlayerState.dead;
			fuel = 0;
			oil = 0;
		}
		
	}
	
	void EmptyGauges(){
		if(PlayerPhysics.instance.state == PlayerPhysics.PlayerState.dead){
			if(fuel > 0 ){
				fuel -= Time.deltaTime*20;
			}
			else if (oil > 0){
				oil -= Time.deltaTime*20;		
			}
		}		
	}
	void DistanceControl()
	{
		if(PlayerPhysics.instance.state == PlayerPhysics.PlayerState.isAlive){
			this.transform.Translate(Vector3.forward * 3 * Time.deltaTime);
			distance += Time.deltaTime;
			fuel -=	 Time.deltaTime;
			oil  -=  Time.deltaTime /1.5f;
		}
		else
		{
			if( distance > highScore){
				highScore = distance;
				highScore = Mathf.RoundToInt(highScore * 10) /10;
				PlayerPrefs.SetFloat("Highscore", highScore);
			}
		}
	}
	
	public void AddFuel(int gas){
		if(fuel <= 80){
			fuel += gas;
		}
		else if (fuel >= 80){
			float pressure = 100 - fuel;
			fuel += pressure + 1;
		}
		
	}
	
	public void AddOil(int fluid){
		if(oil <= 80){
			oil += fluid;
		}
		else if (oil > 80){
			float pressure = 100 - oil;
			oil += pressure;
		}
	}
	
	void UpdateGuages(){
		// handle the oil pin{

        //if(fuel > 0){

        fuelPin.transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            //angle = Mathf.MoveTowardsAngle(fuelPin.transform.localEulerAngles.y, fuel, fuel * 10 * Time.deltaTime);
            //fuelPin.transform.localEulerAngles = new Vector3(0, angle + 180, 0);
            //fuelPin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up) * transform.rotation;
        //}
	}
	
	void CheckLights(){
		
		if(oil <= 30){
			oilPressureLight.gameObject.SetActive(true);
			
		}
		else{
			oilPressureLight.gameObject.SetActive(false);
		}
		
		if(fuel <= 30){
			fuelPressureLight.gameObject.SetActive(true);
		}
		else{
			fuelPressureLight.gameObject.SetActive(false);
		}
		
	}
}

