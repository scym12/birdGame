using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.isPlay)
            Move();
    }

    void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
        transform.position = nextPos + curPos;

        if (transform.position.x < -16)
        {
            curPos = transform.position;
            nextPos = Vector3.right * 32;
            transform.position = nextPos + curPos;
        }

    }
}
