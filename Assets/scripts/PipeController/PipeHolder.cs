using UnityEngine;
using System.Collections;

public class PipeHolder : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// position sử dụng update()
	void Update () {
        if (BirdController.instance != null) 
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        _pipeMovement();
	}

    void _pipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    //hủy pipe
        //ko có thằng nào là trigger
    void OnCollisionEnter2D(Collision2D target)
    {

    }
    // va chạm pipe và destroyPipe
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy")
        {
            Destroy(gameObject); //gameObject chính là pipeHolder
        }
    }
}
