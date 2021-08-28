using UnityEngine;
using System.Collections;
using System;

using System.Collections.Generic;

using UniRx;

public class PlayerMove : MonoBehaviour
{
	public float speed;
	float bpm;
	private float time; //�o�߂������Ԃ��󂯎��ϐ�
	private Camera _fieldCamera;

	[SerializeField] private Transform target;
	[SerializeField] public GameObject locusObject; //���@���甭�����āA���Ɉړ����Ă����I�u�W�F�N�g(�v���n�u)

//	[SerializeField] string FilePath;
	string Title;
	List<GameObject> Notes;
	float ticks;
	List<float> ticksList = new List<float>();


	[Serializable]
	public class InputJson
    {
		public string header;
		public Blocks[] tracks;
    }


	[Serializable]
	public class Blocks
    {
		public int channel;
		public string cintrolChanges;
		public string pitch;
		public string[] instrument;
		public string name;
		public elements[] notes;
		public float end;
    }


	[Serializable]
	public class elements
    {
		public float duration;
		public float durationTicks;
		public float midi;
		public string name;
		public float ticks;
		public float time;
		public float velocity;
    }

	// ���ʂ�ǂݍ��ނ��߂̊֐�
	float JsonReader()
	{
		string inputString = Resources.Load<TextAsset>("Ramen").ToString();

		InputJson inputjson = JsonUtility.FromJson<InputJson>(inputString);
		//Title = json["title"].Get<string>();
		//bpm = 60 / float.Parse(json["bpm"].Get<string>());

		foreach(var track in inputjson.tracks){
			foreach(var note in track.notes)
            {
				ticksList.Add(note.ticks);
			}
		}
		
		return bpm;
	}


	void Start()
    {
		GameObject obj = GameObject.Find("Field Camera");
		_fieldCamera = obj.GetComponent<Camera>();

		ticks = JsonReader();
		Debug.Log(ticksList[0]);

		

		// ��ʂ̒[�_�̍��W
		//		Debug.Log(getScreenTopRight().x);
		//		Debug.Log(getScreenTopRight().y);
		//		Debug.Log(getScreenBottomLeft().x);
		//		Debug.Log(getScreenBottomLeft().y);



		// �R���[�`���̋N��
		StartCoroutine(DelayCoroutine(ticks, () =>
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