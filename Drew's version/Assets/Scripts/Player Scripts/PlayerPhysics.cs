using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
   public float moveSpeed         = 10.0f;
    public float jumpForce         = 10.0f;

    public float wallCheckDistance = 5.0f;
    public float rotateSpeed       = 10.0f;
    public float deltaGround       = 0.3f;
	
    public float gravity          = 40.0f;
    public float terminalVelocity = 38.0f;

    public bool isGrounded   = false;
    private bool hasHitWall   = false;
    private bool isFallingOff = false;
	private bool isJumping = false;

    private int faceDir = 1;

    private Vector3 groundNormal;
    private Vector3 myForward;
    private Vector3 surfaceNormal;
	private Vector3 moveDir;
	
    private PlayerMotor playerMotor;
	
	public int FaceDirection() { return faceDir; }

    void Awake()
    {
        //get the script on this object
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Start()
    {
        surfaceNormal = transform.up;
    }

    void FixedUpdate()
    {
        MotorPhysics();
    }
	
    void MotorPhysics()
    {
        float dir = Input.GetAxisRaw("Horizontal");
				
        if (dir != 0)
        {
            faceDir = (int)dir;
        }
		
        Ray ray;
        RaycastHit hitInfo;

		//detect ground
        if (Physics.Raycast(transform.position, -transform.up, out hitInfo, deltaGround))
        {
           isGrounded = true;

            groundNormal = hitInfo.normal;
        }
        else
        {
            isGrounded = false;
        }
	
		ray = new Ray(transform.position, transform.forward * faceDir);
		
        //check for wall
        if (Physics.Raycast(ray, out hitInfo, wallCheckDistance))
        {
            surfaceNormal = hitInfo.normal;

            hasHitWall = true;
        }
        else
        {
            hasHitWall = false;
        }

		//ray origins
        Vector3 originLeft = transform.position + transform.forward * 0.5f;
        Vector3 originRight = transform.position - transform.forward * 0.5f;
		
		Vector3 dirNormal = new Vector3(0, -groundNormal.z, groundNormal.y);
		
        if (isGrounded)
        {
			if (Input.GetButtonDown("Jump"))
			{
				rigidbody.AddRelativeForce(Vector3.up * jumpForce);
				
				isJumping = true;
			}
			
			if (!isJumping)
			{
				moveDir = dirNormal * moveSpeed * dir;
			}
			
			isJumping = false;
			
			rigidbody.velocity = moveDir;
			
			//check if on edge on left or right
            if (!Physics.Raycast(originLeft, -transform.up, out hitInfo, deltaGround))
            {				
                isFallingOff = true;
            }
            else if (!Physics.Raycast(originRight, -transform.up, out hitInfo, deltaGround))
            {				
                isFallingOff = true;
            }
            else
            {
                isFallingOff = false;
            }
        }
		
		//variable to push the character down a bit to get onto the side of the wall
        Vector3 newPos = transform.TransformPoint(Vector3.down * 0.5f);
		
        if (isFallingOff)
        {
            Vector3 myUp = Vector3.Cross(-transform.right, groundNormal);
            Quaternion newRot = Quaternion.LookRotation(myUp, groundNormal);
            
			//move the character down and rotate
            transform.position = Vector3.Lerp(transform.position, newPos, rotateSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotateSpeed);
		}
  
        if (hasHitWall)
        {
            myForward = Vector3.Cross(transform.right, surfaceNormal);
            Quaternion targetRot = Quaternion.LookRotation(myForward, surfaceNormal);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotateSpeed);
        }
		
		//apply gravity
		if (!isGrounded)
		{
        	rigidbody.AddRelativeForce(Vector3.down * gravity);
		}
		
		Debug.DrawRay(transform.position, (transform.forward * faceDir) * wallCheckDistance, Color.blue);
		
		Debug.DrawRay(originLeft, -transform.up * deltaGround, Color.green);
        Debug.DrawRay(originRight, -transform.up * deltaGround, Color.black);
		
		Debug.DrawRay(transform.position, -transform.up * deltaGround, Color.red);
    }
}