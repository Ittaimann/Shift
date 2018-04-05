using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	public Orientation orientation;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravityForce = 20.0F;
	private Rigidbody rb;

    float rotationY = 0F;
	public float MinY;
	public float MaxY;


	public float SensitivityX;
	public float SensitivityY;

    public GameObject cam;
	
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		orientation = GetComponent<Orientation>();
	
	}
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main.gameObject;
	}

	void Update()
	{
        rotationY += Input.GetAxis("Mouse Y")*SensitivityY;
        rotationY = Mathf.Clamp( rotationY, MinY, MaxY );
		cam.transform.localEulerAngles = new Vector3( -rotationY, 0, 0 );


		Quaternion deltaRotation = Quaternion.Euler(0,Input.GetAxis("Mouse X")*SensitivityX,0);
		transform.Rotate(deltaRotation.eulerAngles);
		//rb.MoveRotation(Quaternion.Euler( rb.rotation.eulerAngles + deltaRotation.eulerAngles ));

		
		if(Input.anyKeyDown)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				orientation.movement = Direction.forward;
			}
			if(Input.GetKeyDown(KeyCode.S))
			{
				orientation.movement = Direction.backward;
			}
			if(Input.GetKeyDown(KeyCode.A))
			{
				orientation.movement = Direction.left;
			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				orientation.movement = Direction.right;
			}
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				orientation.Shift();
			}
		}
		else if (!Input.anyKey)
		{
			orientation.movement = Direction.none;
		}
		rb.velocity=(transform.right*Input.GetAxisRaw("Horizontal") +transform.forward* Input.GetAxisRaw("Vertical"))*speed;
		rb.AddRelativeForce(orientation.gravity*gravityForce);
	}
}