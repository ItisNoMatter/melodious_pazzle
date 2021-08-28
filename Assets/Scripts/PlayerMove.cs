using UnityEngine;
using System.Collections;
using System;

using System.Collections.Generic;

using UniRx;

public class PlayerMove : MonoBehaviour
{
	public float speed;
	private Camera _fieldCamera;
	private float delay;


	[SerializeField] private Transform target;
	[SerializeField] public GameObject locusObject; //�ｽ�ｽ�ｽ@�ｽ�ｽ�ｽ逕ｭ�ｽ�ｽ�ｽ�ｽ�ｽﾄ、�ｽ�ｽ�ｽﾉ移難ｿｽ�ｽ�ｽ�ｽﾄゑｿｽ�ｽ�ｽ�ｽI�ｽu�ｽW�ｽF�ｽN�ｽg(�ｽv�ｽ�ｽ�ｽn�ｽu)
	

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

	// 譜面を読み込むための関数
	public void JsonReader()
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
	}


	void Start()
    {

		JsonReader();

		GameObject obj = GameObject.Find("Field Camera");
		_fieldCamera = obj.GetComponent<Camera>();

		//遅れる秒数を変化させたい
		delay = (ticksList[1] - ticksList[0])/1000;

		// コルーチンの起動
		StartCoroutine(DelayCoroutine(delay, () =>
		{
			// X秒後にここの処理が実行される
			Instantiate(locusObject, this.transform.position, Quaternion.identity);
		}));

	}

	// �ｽ�ｽ闔橸ｿｽﾔ鯉ｿｽﾉ擾ｿｽ�ｽ�ｽ�ｽ�ｽ�ｽﾄび出�ｽ�ｽ�ｽR�ｽ�ｽ�ｽ[�ｽ`�ｽ�ｽ
	private IEnumerator DelayCoroutine(float seconds, Action action)
	{
		while (true)
		{
			yield return new WaitForSeconds(seconds);
			action?.Invoke();
			for (int n = 1; n < ticksList.Count - 1; n++) 
			{ 
				seconds = (ticksList[n + 1] - ticksList[n]) / 1000;
				yield return new WaitForSeconds(seconds);
				action?.Invoke();
				Debug.Log(seconds);
            }
		}
	}


	// Update is called once per frame
	void Update()
	{
		Vector3 playerPosition = target.position;

		
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
		// �ｽ�ｽﾊの搾ｿｽ�ｽ�ｽ�ｽ�ｽ謫ｾ
		Vector3 bottomLeft = _fieldCamera.ScreenToWorldPoint(Vector3.zero);
		return bottomLeft;
	}

	private Vector3 getScreenTopRight()
	{
		// �ｽ�ｽﾊの右�ｽ�ｽ�ｽ�ｽ�ｽ謫ｾ
		Vector3 topRight = _fieldCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
		return topRight;
	}
}