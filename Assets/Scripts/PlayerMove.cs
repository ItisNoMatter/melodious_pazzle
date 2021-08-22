using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float speed = 30.0f;

	[SerializeField] private Transform target;

	void Start()
    {
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = target.position;

		if (Input.GetKey("right"))
		{
			if (pos.y < -4.8)
			{
				transform.position -= transform.right * speed * Time.deltaTime;
				Debug.Log(pos);
			}
			else
			{
				transform.position += transform.right * speed * Time.deltaTime;
			}

		}
		if (Input.GetKey("left"))
		{
			if (pos.y > 5.6)
			{
				transform.position += transform.right * speed * Time.deltaTime;
				Debug.Log(pos);
			}
			else
			{
				transform.position -= transform.right * speed * Time.deltaTime;
			}
		}
		if (Input.GetKey("up"))
		{
			transform.position += transform.up * speed * Time.deltaTime;
		}
		if (Input.GetKey("down"))
		{
			transform.position -= transform.up * speed * Time.deltaTime;
		}

		//Vector3 pos = target.position;

		// Debug.Log(pos); // zç¿ïWÇ™â¬ïœ

	}
}