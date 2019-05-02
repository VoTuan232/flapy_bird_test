using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void _playButton()
    {
        //Application.LoadLevel("game");
        SceneManager.LoadScene("game");
    }
}
