using UnityEngine;
using System.Collections;

public class SpawnerPipe : MonoBehaviour {
    [SerializeField]
    private GameObject pipeHolder;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1); //1s sinh ra holder pipe

        //random trục y của spawner
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2f, 2f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
