using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject spawnpoint_C2;
    public GameObject spawnpoint_B;
    public GameObject spawnpoint_A;
    public GameObject spawnpoint_G;
    public GameObject spawnpoint_F;
    public GameObject spawnpoint_E;
    public GameObject spawnpoint_D;
    public GameObject spawnpoint_C;

    ObjectSpawn script_C2;
    ObjectSpawn script_B;
    ObjectSpawn script_A;
    ObjectSpawn script_G;
    ObjectSpawn script_F;
    ObjectSpawn script_E;
    ObjectSpawn script_D;
    ObjectSpawn script_C;

    // Start is called before the first frame update
    void Start()
    {

        //script_C2 = spawnpoint_C2.GetComponent<ObjectSpawn>();
        

        //script_C2.obstacleGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
