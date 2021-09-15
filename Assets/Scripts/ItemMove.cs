using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float speed;
    private float step_time;　//経過した時間を受け取る変数

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;  // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;
        transform.position -= transform.right * speed * Time.deltaTime;
        step_time = 0.0f;  // 経過時間初期化

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
