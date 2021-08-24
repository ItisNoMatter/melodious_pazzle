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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Respawn")
        {
            audiosource.PlayOneShot(audioclip);
            Debug.Log("“–‚½‚è‚Ü‚µ‚½");
        }
    }
}
