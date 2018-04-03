using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	public ShiftOrientation shifter;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravityForce = 20.0F;
	private Rigidbody rb;
	private Vector3 gravityVector;

    float rotationY = 0F;
	public float MinY;
	public float MaxY;


	public float SensitivityX;
	public float SensitivityY;

    public GameObject cam;
	
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		shifter = GetComponent<ShiftOrientation>();
	
	}
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main.gameObject;
	}

	void Update()
	{

        Quaternion deltaRotation = Quaternion.Euler(0,Input.GetAxis("Mouse X")*SensitivityX,0);


        rotationY +=Input.GetAxis("Mouse Y")*SensitivityY;

        rotationY=Mathf.Clamp( rotationY, MinY, MaxY );
		
		cam.transform.localEulerAngles = new Vector3( -rotationY, 0, 0 );


		rb.MoveRotation(Quaternion.Euler( rb.rotation.eulerAngles + deltaRotation.eulerAngles ));

		
		if(Input.anyKeyDown)
		{
			if(Input.GetKeyDown(KeyCode.W))
				shifter.movement = Direction.forward;
			if(Input.GetKeyDown(KeyCode.S))
				shifter.movement = Direction.backward;
			if(Input.GetKeyDown(KeyCode.A))
				shifter.movement = Direction.left;
			if(Input.GetKeyDown(KeyCode.D))
				shifter.movement = Direction.right;
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				shifter.Shift();
			}
		}
		rb.velocity=(transform.right*Input.GetAxisRaw("Horizontal") +transform.forward* Input.GetAxisRaw("Vertical"))*speed;
	}
}