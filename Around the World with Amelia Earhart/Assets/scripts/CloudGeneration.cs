using UnityEngine;
using System.Collections.Generic;

public class CloudGeneration : MonoBehaviour
{
	public Transform player;
    public Transform prefab;
    public Transform thisprefab;
	private Transform road;
    public int numOfobjects;
    public float recycleOffset;
    public float distanceCheck;
	public float minGap, maxGap;
    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;
   
	
	
	void Start(){
		minGap = 4;
		maxGap = 20;
		
	}
    // Use this for initialization
    void Awake()
    {
		
        // creates a new queue big as num of objects
        objectQueue = new Queue<Transform>(numOfobjects);
        // fills up the queue with the prefabs.
        for (int i = 0; i < numOfobjects; i++)
        {
            objectQueue.Enqueue((Transform)Instantiate(prefab));
        }
        
         nextPosition = new Vector3((float)Random.Range(-16,16),(float)Random.Range(2,5),(float) Random.Range(-60,-10));
		for (int i = 0; i < numOfobjects; i++)
        {
            Recycle();
        }
    }

    // Update is called once per frame
    public void Update()
    {		
		if (objectQueue.Peek().localPosition.z + recycleOffset < player.position.z)
        {
            Recycle();
        }
		
    }
    private void Recycle()
    {	float offset = (float)Random.Range(minGap, maxGap);
		
        road = objectQueue.Dequeue();
        road.parent = thisprefab;
        road.localPosition = new Vector3((float)Random.Range(-12,12), (float)Random.Range(2,5), nextPosition.z);
        nextPosition.z += offset;
        
        objectQueue.Enqueue(road);
		
    }
}
