/////////////////////////////////////
// BlockTrigger created by patrick rasmussen 
// Script handles the collection, creation and rotation of the blocks.
/////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlockTrigger : MonoBehaviour {
	
	// the orignal block list.
	public List<GameObject> blocks;
	public GameObject t0,t1,t2,t3,t4,t5,t6,t7;
	
	// handles the creation of the blocks.
	public float blockTimer = 0f;
	public int blockCount = 0;
	public bool create = true;
	public int createRotation;
	// Use this for initialization
	void Start () {
		blocks = new List<GameObject>();
		AddBlocks ();
	}
	
	// Update is called once per frame
	void Update () {
		if(blockTimer != 300){
			blockTimer++;	
		}
		else{
			//create = true;
		}
		
		if(create){
			int blocknum = Random.Range(0,7);
			GetRotation();
			float rotX = transform.localRotation.x + createRotation;
			Quaternion spawnRot = new Quaternion(rotX,0 ,0,0);
			Vector3 spawnPos = transform.position;
			Instantiate(blocks[blocknum] as GameObject, spawnPos, spawnRot);
			create = false;
		}
	
	}
	public void GetRotation(){
			int result = Random.Range (0,3);
			if(result == 0)
				createRotation = 0;
			else if(result == 1)
				createRotation = 90;
			else if(result == 2)
				createRotation = 180;
			else if(result == 3)
				createRotation = 270;
			else{
				createRotation = 0;
			}
	}
	public void AddBlocks(){
		blocks.Add(t0);
		blocks.Add(t1);
		blocks.Add(t2);
		blocks.Add(t3);
		blocks.Add(t4);
		blocks.Add(t5);
		blocks.Add(t6);
		blocks.Add(t7);
		
		}
		
}