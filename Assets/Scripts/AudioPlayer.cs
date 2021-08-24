using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]AudioClip audioclip;
    AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
        
            audiosource.PlayOneShot(audioclip);
            Destroy(other.gameObject);
            Debug.Log("“–‚½‚è‚Ü‚µ‚½");
        
    }
    /*{
        if (other.collider.tag == "notes")
        {
            audiosource.PlayOneShot(audioclip);
            Destroy(other.gameObject);
            Debug.Log("“–‚½‚è‚Ü‚µ‚½");
        }
    }*/
}
