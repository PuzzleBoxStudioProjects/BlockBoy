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
        transform.position = player.transform.position;
        //transform.rotation = Quaternion.LookRotation(transform.forward * playerPhysics.faceDir);
        //transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, rotationAngle, 10 * playerPhysics.faceDir), player.transform.eulerAngles.z);
	}
}
