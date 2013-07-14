using UnityEngine;
using System.Collections.Generic;

public class WaterGeneration : MonoBehaviour
{
	public Transform player;
    public Transform prefab;
    public Transform thisprefab;
	private Transform road;
    public int numOfobjects;
    public float recycleOffset;
    public float distanceCheck;
    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;
   
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
    {
        road = objectQueue.Dequeue();
        road.parent = thisprefab;
        road.localPosition = nextPosition;
        nextPosition.z += 80.0f;
        
        objectQueue.Enqueue(road);
		;
    }
}
