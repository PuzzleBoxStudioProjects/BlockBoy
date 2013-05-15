using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{
    public float rotationAngle;

    private GameObject player;
    private PlayerPhysics playerPhysics;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerPhysics = player.GetComponent<PlayerPhysics>();
    }
    	
	void LateUpdate ()
    {
		//rotate to face direction
		transform.localRotation = Quaternion.LookRotation(Vector3.forward * playerPhysics.FaceDirection());
	}
}
