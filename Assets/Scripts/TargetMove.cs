using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    //public float speed = 1.0f;
    private AudioSource audioSource;
    private Vector3 position;

    [SerializeField] private Transform target;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        position = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(Time.time * 1.0f + position.x, position.y, position.y);

        //if (Vector3.Distance(transform.position,target.position)<0.001f)
        //{
        //        audioSource.Play();
        //}
    }
}