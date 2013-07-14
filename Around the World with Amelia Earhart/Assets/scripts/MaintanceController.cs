using UnityEngine;
using System.Collections.Generic;

public class MaintanceController: MonoBehaviour
{
	public Transform player;
    public Transform gasTank;
	public Transform oilCan;
    public Transform powerUpObject;
	private Transform clones, clones2;
    public int numOfobjects;
    public float recycleOffset;
    public float distanceCheck;
	public float minGap, maxGap;
    private Vector3 nextPosition;
    private Queue<Transform> oilcanQueue;
   	private Queue<Transform> gastankQueue;
	
	
	void Start(){
		minGap = 20;
		maxGap = 60;
		
	}
    // Use this for initialization
    void Awake()
    {
		
        // creates a new queue big as num of objects
        oilcanQueue = new Queue<Transform>(numOfobjects);
		gastankQueue = new Queue<Transform>(numOfobjects);
        // fills up the queue with the prefabs.
        for (int i = 0; i < numOfobjects; i++)
        {
            oilcanQueue.Enqueue((Transform)Instantiate(gasTank));
        }
        for (int i = 0; i < numOfobjects; i++)
        {
            gastankQueue.Enqueue((Transform)Instantiate(oilCan));
        }
         nextPosition = new Vector3(Random.Range(-16,16),player.position.y, Random.Range(-60,-10));
		for (int i = 0; i < numOfobjects; i++)
        {
            RecycleGas();
        }
		for (int i = 0; i < numOfobjects; i++)
        {
            RecycleOil();
        }
		
    }

    // Update is called once per frame
    public void Update()
    {		
		if (gastankQueue.Peek().localPosition.z + recycleOffset < player.position.z)
        {
            RecycleGas();
        }
		if (oilcanQueue.Peek().localPosition.z + recycleOffset < player.position.z)
        {
            RecycleOil();
        }
    }
    private void RecycleGas()
    {	float offset =(float)Random.Range(minGap, maxGap);

		
		clones2 = gastankQueue.Dequeue();
        clones2.parent = powerUpObject;
        clones2.localPosition = new Vector3((float)Random.Range(-12,12), player.position.y, nextPosition.z);
        nextPosition.z += offset;        
        gastankQueue.Enqueue(clones2);
    }
	
	private void RecycleOil()
    {	float offset =(float)Random.Range(minGap, maxGap);
		
        clones = oilcanQueue.Dequeue();
        clones.parent = powerUpObject;
        clones.localPosition = new Vector3((float)Random.Range(-12,12), player.position.y, nextPosition.z);
        nextPosition.z += offset;        
        oilcanQueue.Enqueue(clones);
		
    }
}