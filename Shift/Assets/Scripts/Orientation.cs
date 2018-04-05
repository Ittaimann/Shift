using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	none,
	forward,
	backward,
	left,
	right
}

public class Orientation : MonoBehaviour 
{
	public Direction movement;
	public Vector3 gravity = Vector3.down;

	public void Shift()
	{
		switch(movement)
		{
			case Direction.none:
			break;
			case Direction.forward:
			this.transform.Rotate(Vector3.right * 90f);
			this.transform.rotation = RoundXAndZToNearest90(this.transform.rotation);
			break;
			case Direction.backward:
			this.transform.Rotate(Vector3.left * 90f);
			this.transform.rotation = RoundXAndZToNearest90(this.transform.rotation);
			break;
			case Direction.left:
			this.transform.Rotate(Vector3.forward * 90f);
			this.transform.rotation = RoundXAndZToNearest90(this.transform.rotation);
			break;
			case Direction.right:
			this.transform.Rotate(Vector3.back * 90f);
			this.transform.rotation = RoundXAndZToNearest90(this.transform.rotation);
			break;
		}
	}
	private Quaternion RoundXAndZToNearest90(Quaternion input)
	{
		Vector3 eulerangles = input.eulerAngles;
		return Quaternion.Euler( Mathf.Round(eulerangles.x / 90f) * 90f,
							   eulerangles.y,
							   Mathf.Round(eulerangles.z / 90f) * 90f );
	}
}


