using UnityEngine;
using System.Collections;
using System;

public class PlayerMove : MonoBehaviour
{
	public float speed;
	public float bpm;
	private float time; //�o�߂������Ԃ��󂯎��ϐ�
	private float cycle;
	private Camera _fieldCamera;
	[SerializeField] private Transform target;
	[SerializeField] public GameObject locusObject; //���@���甭�����āA���Ɉړ����Ă����I�u�W�F�N�g(�v���n�u)
	

	void Start()
    {
		GameObject obj = GameObject.Find("Field Camera");
		_fieldCamera = obj.GetComponent<Camera>();
		cycle=60/bpm;

		// ��ʂ̒[�_�̍��W
		Debug.Log(getScreenTopRight().x);
		Debug.Log(getScreenTopRight().y);
		Debug.Log(getScreenBottomLeft().x);
		Debug.Log(getScreenBottomLeft().y);

		// �R���[�`���̋N��
		StartCoroutine(DelayCoroutine(cycle, () =>
		{
			// 0.5�b��ɂ����̏��������s�����
			Instantiate(locusObject, this.transform.position, Quaternion.identity);
		}));

	}

	// ��莞�Ԍ�ɏ������Ăяo���R���[�`��
	private IEnumerator DelayCoroutine(float seconds, Action action)
	{
		while (true)
		{
			yield return new WaitForSeconds(seconds);
			action?.Invoke();
		}
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
		// ��ʂ̍�����擾
		Vector3 bottomLeft = _fieldCamera.ScreenToWorldPoint(Vector3.zero);
		return bottomLeft;
	}

	private Vector3 getScreenTopRight()
	{
		// ��ʂ̉E�����擾
		Vector3 topRight = _fieldCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
		return topRight;
	}
}