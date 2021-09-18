using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StartDelay : MonoBehaviour
{
    public AudioClip BGM;
    AudioSource audiosource;
    

    // Start is called before the first frame update
    void Start()
    {
        audiosource=GetComponent<AudioSource>();
        StartCoroutine(DelayCoroutine((5.655f), () =>
		{
			// X秒後にここの処理が実行される
			audiosource.PlayOneShot(BGM);
		}));
    }

    // Update is called once per frame
    void Update()
    {
       
            
        
    }
    private IEnumerator DelayCoroutine(float seconds, Action action)
	{
		yield return new WaitForSeconds(seconds);
        action?.Invoke();
	}
}
