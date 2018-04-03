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

public class ShiftOrientation : MonoBehaviour 
{
	public Direction movement;

	public void Shift()
	{
		switch(movement)
		{
			case Direction.none:
			break;
			case Direction.forward:
			this.transform.Rotate(Vector3.right * 90f);
			break;
			case Direction.backward:
			this.transform.Rotate(Vector3.left * 90f);
			break;
			case Direction.left:
			this.transform.Rotate(Vector3.forward * 90f);
			break;
			case Direction.right:
			this.transform.Rotate(Vector3.back * 90f);
			break;
		}
	}
}
