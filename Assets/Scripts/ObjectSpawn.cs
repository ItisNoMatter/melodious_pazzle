
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectSpawn : MonoBehaviour
{
    
	public GameObject obstacle;


    public GameObject item;
	private float delay;
    string Title;
	List<GameObject> Notes;
	float ticks;
	//List<float> ticksList = new List<float>();
	List<float> timeList=new List<float>();
    List<string> nameList=new List<string>();
	List<float> melodyscore=new List<float>();
	private  int melodycount;

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
		//4拍で1920ticks
		//1拍で480ticks
		//150拍で60s
		//480*150ticksで60s
		//480*150/60ticksで1s
		//60/(480*150)sで1ticks
		//delay = ((ticksList[0])*(60/(480*150)));
		//delay = ticksList[0]/1000;
		delay = timeList[0];

		foreach(string melody in nameList){
			if(melody=="D4"){
				melodyscore.Add(-2.75f);
			}
			if(melody=="E4"){
				melodyscore.Add(-2.05f);
			}
			if(melody=="F#4"){
				melodyscore.Add(-1.4f);
			}
			if(melody=="G4"){
				melodyscore.Add(-0.7f);
			}
			if(melody=="A4"){
				melodyscore.Add(0f);
			}
			if(melody=="B4"){
				melodyscore.Add(0.7f);
			}
			if(melody=="C5"){
				melodyscore.Add(1.35f);
			}
			if(melody=="D5"){
				melodyscore.Add(2.0f);
			}
			if(melody=="E5"){
				melodyscore.Add(2.65f);
			}
			if(melody=="F5"){
				melodyscore.Add(3.3f);
			}
			if(melody=="G5"){
				melodyscore.Add(4.0f);
			}
			if(melody=="A5"){
				melodyscore.Add(4.75f);
			}
		}
		

		// コルーチンの起動
		StartCoroutine(DelayCoroutine(delay, () =>
		{
			// X秒後にここの処理が実行される
			Instantiate(item,new Vector2(6.0f,melodyscore[melodycount]), Quaternion.identity);
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

		foreach(var track in inputjson.tracks){
			foreach(var note in track.notes)
            {
				//ticksList.Add(note.ticks);
                nameList.Add(note.name);
				timeList.Add(note.time);
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
				//seconds = (ticksList[n + 1] - ticksList[n])*(60/(480*150));
				//seconds = (ticksList[n + 1] - ticksList[n])/1000;
				seconds = (timeList[n + 1] - timeList[n]);
				yield return new WaitForSeconds(seconds);
				action?.Invoke();
				
            }
		}
	}
    public void syougaibutuGeneration()

    {
        Instantiate(obstacle, this.transform.position, Quaternion.identity);
    }

    public void itemGenerate()
    {
        Instantiate(power_item1, this.transform.position, Quaternion.identity);
    }

    public void coinGenerate()
    {

    }
}
