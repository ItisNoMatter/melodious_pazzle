using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float speed = 30.0f;

	private Camera _fieldCamera;
	[SerializeField] private Transform target;

	void Start()
    {
		GameObject obj = GameObject.Find("Field Camera");
		_fieldCamera = obj.GetComponent<Camera>();

		// 画面の端点の座標
		Debug.Log(getScreenTopRight().x);
		Debug.Log(getScreenTopRight().y);
		Debug.Log(getScreenBottomLeft().x);
		Debug.Log(getScreenBottomLeft().y);

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 playerPosition = target.position;

		if (Input.GetKey("right"))
		{
			if (playerPosition.x > getScreenTopRight().x)
			{
				transform.position -= transform.right * speed * Time.deltaTime;
			}
			else
			{
				transform.position += transform.right * speed * Time.deltaTime;
			}

		}
		if (Input.GetKey("left"))
		{
			if (playerPosition.x < getScreenBottomLeft().x)
			{
				transform.position += transform.right * speed * Time.deltaTime;
			}
			else
			{
				transform.position -= transform.right * speed * Time.deltaTime;
			}
		}
		if (Input.GetKey("up"))
		{
			if (playerPosition.y > getScreenTopRight().y)
			{
				transform.position -= transform.up * speed * Time.deltaTime;
			}
            else
			{
				transform.position += transform.up * speed * Time.deltaTime;
			}
		}
		if (Input.GetKey("down"))
		{
			if (playerPosition.y < getScreenBottomLeft().y)
			{
				transform.position += transform.up * speed * Time.deltaTime;
			}
			else
			{
				transform.position -= transform.up * speed * Time.deltaTime;
			}
		}

	}

	private Vector3 getScreenBottomLeft()
	{
		// 画面の左上を取得
		Vector3 bottomLeft = _fieldCamera.ScreenToWorldPoint(Vector3.zero);
		return bottomLeft;
	}

	private Vector3 getScreenTopRight()
	{
		// 画面の右下を取得
		Vector3 topRight = _fieldCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
		return topRight;
	}
}