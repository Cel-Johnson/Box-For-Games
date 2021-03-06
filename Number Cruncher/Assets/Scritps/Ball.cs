
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] AudioClip[] ballSounds;

    bool done = false;
    bool launch = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if  (!launch)
        {
            LockBallToPaddle();
        }
        if (!done)
        {
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            done = true;
            launch = true;
            myRigidbody2D.velocity = new Vector2(xPush,yPush);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new  Vector2
            (Random.Range(0f, randomFactor)
           , Random.Range(0f, randomFactor));
        if (launch) 
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}

