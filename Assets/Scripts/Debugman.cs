using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugman : MonoBehaviour
{
    bool touch=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        //speed=1で2.34sでlocusobjectはピアノに到達
        //speed=2で4.178sでitemはPlayerに到達

    }
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag=="Player"){

            Destroy(this.gameObject);
        }
    }

    
}
