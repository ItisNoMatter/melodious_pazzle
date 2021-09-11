using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject obstacle;

    public GameObject power_item1,power_item2,power_item3;

    public GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void obstacleGenerate()
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
