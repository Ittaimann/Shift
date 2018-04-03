using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
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
	
	}
	void Start()
	{
        cam = Camera.main.gameObject;
	}

	void Update()
	{
        Quaternion deltaRotation = Quaternion.Euler(0,Input.GetAxis("Mouse X")*SensitivityX,0);




        rotationY +=Input.GetAxis("Mouse Y")*SensitivityY;

        rotationY=Mathf.Clamp( rotationY, MinY, MaxY );
		
		cam.transform.localEulerAngles = new Vector3( -rotationY, 0, 0 );


	

		rb.MoveRotation(Quaternion.Euler( rb.rotation.eulerAngles + deltaRotation.eulerAngles ));

		
		
		
		rb.velocity=(transform.right*Input.GetAxisRaw("Horizontal") +transform.forward* Input.GetAxisRaw("Vertical"))*speed;
	}
}