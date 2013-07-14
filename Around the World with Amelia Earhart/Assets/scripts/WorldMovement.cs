using UnityEngine;
using System.Collections;

public class WorldMovement : MonoBehaviour {
	public static float distance;
	// Use this for initialization
	void Start () {
	distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(Vector3.back * 4 * Time.deltaTime);
		distance += this.gameObject.transform.position.z ;
	}
}
