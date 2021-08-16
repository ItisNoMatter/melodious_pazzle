using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float speed = 10.0f;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("right"))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey("left"))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
	}
}