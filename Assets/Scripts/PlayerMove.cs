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
			if (pos.z < -4.8)
			{
				// pos.z = -4.9f;
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
			if (pos.z > 5.6)
			{
				// pos.z = 5.7f;
				transform.position += transform.right * speed * Time.deltaTime;
				Debug.Log(pos);
			}
			else
			{
				transform.position -= transform.right * speed * Time.deltaTime;
			}
		}

		//Vector3 pos = target.position;

		// Debug.Log(pos); // zç¿ïWÇ™â¬ïœ

	}
}