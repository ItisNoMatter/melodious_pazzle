using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject syougaibutu;

    public GameObject item;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void syougaibutuGeneration()
    {
        Instantiate(syougaibutu);
    }

    public void itemGeneration()
    {
        Instantiate(item);
    }
}
