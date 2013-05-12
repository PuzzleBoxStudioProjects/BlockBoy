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
		transform.position -= target.transform.position * Time.deltaTime;
		transform.Translate(Vector3.up * blockSpeed * Time.deltaTime);
	}
	
	
}
