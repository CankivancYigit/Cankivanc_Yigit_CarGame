using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour 
{

	//Eklendigi objenin belirlenen koordinatlardan cikmamasini saglar.
	void Update ()
	{
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.4f, 8.4f),
			Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
	}
}
