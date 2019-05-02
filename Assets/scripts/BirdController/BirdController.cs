using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    //serialize : để private có thể chỉnh tại unity
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    // khi bird va chạm
    public static BirdController instance;
    public float flag = 0; // move pipeHolder
    private GameObject spwaner; //repeate pipeHolder

    public int score = 0;

	// Use this for initialization
	void Awake () {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _makeInstance();
        spwaner = GameObject.Find("Spawner Pipe");
    }

    void _makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	
	// Truyền vật lí dùng FixedUpdate
	void FixedUpdate () {
        _birdMoveMent();
	}

    void _birdMoveMent()
    {
        if (isAlive)
        {
            //khi đã ấn vào button để start
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        // khi nhấn chuột trái
        //if (Input.GetMouseButtonDown (0))
        //{
        //    myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
        //    audioSource.PlayOneShot(flyClip);
        //}
        // rotate bird when up and down
        if (myBody.velocity.y > 0)
        {
            float angle1 = 0;
            angle1 = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle1);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angle1 = 0;
            angle1 = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle1);
        }
    }

    public void flapButton()
    {
        didFlap = true;
    }

    // bird đi qua pipe
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._setScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    // bird va chạm pipe hoặc ground
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spwaner);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
        }
        if (GamePlayController.instance != null)
        {
            GamePlayController.instance._showPanelDied(score);
        }
    }

   
}

//đk va chạm: 2 đứa đề có collider và 1 trong 2 có rigidbody
//collider nhưng istrigger là true => có thể đi xuyên