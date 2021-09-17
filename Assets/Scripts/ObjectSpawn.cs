using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectSpawn : MonoBehaviour
{
	public GameObject obstacle;
	public GameObject power_item_1;
	public GameObject power_item_2;
	public GameObject score_item;

	GameObject[] itemBox = new GameObject[3];

	private float delay;
	string Title;
	List<GameObject> Notes;
	float ticks;
	//List<float> ticksList = new List<float>();
	List<float> timeList=new List<float>();
	List<string> nameList = new List<string>();
	List<float> melodyscore = new List<float>();
	private int melodycount;
	int index;

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


    public GameObject power_item1,power_item2,power_item3;

    public GameObject coin;

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
	// Start is called before the first frame update
	void Start()
	{
		JsonReader();
		//遅れる秒数を変化させたい
		delay = timeList[0];

		foreach (string melody in nameList)
		{
			if (melody == "D4")
			{
				melodyscore.Add(-2.75f);
			}
			if (melody == "E4")
			{
				melodyscore.Add(-2.05f);
			}
			if (melody == "F#4")
			{
				melodyscore.Add(-1.4f);
			}
			if (melody == "G4")
			{
				melodyscore.Add(-0.7f);
			}
			if (melody == "A4")
			{
				melodyscore.Add(0f);
			}
			if (melody == "B4")
			{
				melodyscore.Add(0.7f);
			}
			if (melody == "C5")
			{
				melodyscore.Add(1.35f);
			}
			if (melody == "D5")
			{
				melodyscore.Add(2.0f);
			}
			if (melody == "E5")
			{
				melodyscore.Add(2.65f);
			}
			if (melody == "G5")
			{
				melodyscore.Add(3.3f);
			}
			if (melody == "B5")
			{
				melodyscore.Add(4.0f);
			}
			if (melody == "D6")
			{
				melodyscore.Add(4.75f);
			}

			//アイテム配列にゲームオブジェクトを挿入
			itemBox[0] = power_item_1;
			itemBox[1] = power_item_2;
			itemBox[2] = score_item;
		}

		// コルーチンの起動
		StartCoroutine(DelayCoroutine(delay, () =>
		{
            //乱数の生成
            System.Random random = new System.Random();
			index = random.Next(0, 3);

			// X秒後にここの処理が実行される

			// TODO:生成アイテムを乱数で変化させたい
			// 0から2の間で乱数を発生させ、出現アイテムを変化させる
			Instantiate(itemBox[index], new Vector2(6.0f, melodyscore[melodycount]), Quaternion.identity);


			//とりあえず空間ができるように障害物を配置

			// TODO:障害物の配置方法の検討
			Instantiate(obstacle, new Vector2(6.0f, melodyscore[melodycount] - 3), Quaternion.identity);
			Instantiate(obstacle, new Vector2(6.0f, melodyscore[melodycount] + 3), Quaternion.identity);

			melodycount++;
		}));
	}

	// Update is called once per frame
	void Update()
	{

	}

	// 譜面を読み込むための関数
	public void JsonReader()
	{
		string inputString = Resources.Load<TextAsset>("melody").ToString();

		InputJson inputjson = JsonUtility.FromJson<InputJson>(inputString);
		//Title = json["title"].Get<string>();
		//bpm = 60 / float.Parse(json["bpm"].Get<string>());

		foreach (var track in inputjson.tracks)
		{
			foreach (var note in track.notes)
			{
				timeList.Add(note.time);
				nameList.Add(note.name);
			}
		}
	}
	// 一定時間後に処理を呼び出すコルーチン
	private IEnumerator DelayCoroutine(float seconds, Action action)
	{
		while (true)
		{
			yield return new WaitForSeconds(seconds);
			action?.Invoke();
			for (int n = 0; n < timeList.Count - 1; n++)
			{
				seconds = (timeList[n + 1] - timeList[n]);
				yield return new WaitForSeconds(seconds);
				action?.Invoke();

			}
		}
	}	
}
