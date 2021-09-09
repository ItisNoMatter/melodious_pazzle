using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip audioclip;
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

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "notes")
        {
            Destroy(other.gameObject);

            this.gameObject.GetComponent<Renderer>().material.color = Color.red;                       
            audiosource.PlayOneShot(audioclip);
            yield return new WaitForSeconds(1.0f);
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }

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