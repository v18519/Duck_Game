using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera camera;
    public AudioSource sound;
    public GameObject duck;
    RotatePlayerSprite duck_rot;

    GameObject nest;
    BuildNest buildNestScript;

    GameObject gameManager;
    GameManagerScript gameManagerScript;

    public const double horizonalSpeed = 500;
    public const double verticalSpeed = 460;
    public const double vGrav = -160;

    private Rigidbody2D rb;
    private bool flightAllowed = true;
    public bool flightStarted = false;
    public Animator anim;
    // public bool inAir;
    float flightTime = 5;
    private Vector2 Vel;
    private bool turn;
    public bool isinWater = false;

    public bool uncontrollable = false;

    public AudioSource fall;

    //Android specific
    float screenWidth, screenHeight;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        duck_rot = duck.GetComponent<RotatePlayerSprite>();

        nest = GameObject.FindGameObjectWithTag("Nest");
        buildNestScript = nest.GetComponent<BuildNest>();

        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        fall = GetComponent<AudioSource>();
        bool turn = false;

        if (Application.platform == RuntimePlatform.Android)
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }
    }

    void FixedUpdate()
    {
        if (flightStarted)
            flightTime -= Time.deltaTime;

        bool horizontal = false;


        Debug.Log(uncontrollable);
        if (!uncontrollable)
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetButton("Left") && Input.GetButton("Fly"))
                {
                    if (!flightStarted) flightStarted = true;
                    anim.SetBool("inAir", true);
                    MoveLeftAndUp();
                    if (turn == true)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = false;
                    };

                }

                else if (Input.GetButton("Right") && Input.GetButton("Fly"))
                {
                    if (!flightStarted) flightStarted = true;
                    anim.SetBool("inAir", true);
                    MoveRightAndUp();
                    if (turn == false)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = true;
                    }

                }

                else if (Input.GetButton("Left"))
                {
                    MoveLeft();
                    horizontal = true;
                    anim.SetBool("turn", false);
                    Debug.Log("turnleft");
                    if (turn == true)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = false;
                    };
                }

                else if (Input.GetButton("Right"))
                {
                    MoveRight();
                    horizontal = true;
                    anim.SetBool("turn", true);
                    Debug.Log("turnright");
                    if (turn == false)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = true;
                    }
                }

                else if (Input.GetButton("Fly"))
                {
                    if (!flightStarted) flightStarted = true;
                    anim.SetBool("inAir", true);
                    Fly();
                }
                else if (!Input.GetButton("Fly"))
                {
                    duck_rot.SetZ(0);
                    Vel = new Vector2(0, 0);
                }
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                Vector2 touch = Input.GetTouch(Input.touchCount).position;
                if (touch.x < screenHeight / 2 && touch.y > screenWidth / 2)
                {
                    if (!flightStarted) flightStarted = true;
                    anim.SetBool("inAir", true);
                    MoveLeftAndUp();
                    if (turn == true)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = false;
                    };

                }

                else if (touch.x > screenHeight / 2 && touch.y > screenWidth / 2)
                {
                    if (!flightStarted) flightStarted = true;
                    anim.SetBool("inAir", true);
                    MoveRightAndUp();
                    if (turn == false)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = true;
                    }

                }

                else if (touch.x < screenHeight / 2)
                {
                    MoveLeft();
                    horizontal = true;
                    anim.SetBool("turn", false);
                    Debug.Log("turnleft");
                    if (turn == true)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = false;
                    };
                }

                else if (touch.x > screenHeight / 2)
                {
                    MoveRight();
                    horizontal = true;
                    anim.SetBool("turn", true);
                    Debug.Log("turnright");
                    if (turn == false)
                    {
                        transform.Rotate(Vector3.up * 180);
                        turn = true;
                    }
                }
                else
                {
                    duck_rot.SetZ(0);
                    Vel = new Vector2(0, 0);
                }
            }
        }
        rb.velocity = new Vector2(0, (float)vGrav * Time.deltaTime) + Vel;
        duck_rot.DoRotation();
    }

    void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    void MoveLeftAndUp()
    {
        if (flightTime > 0)
        {
            Vel = new Vector2((float)-horizonalSpeed * Time.deltaTime, (float)verticalSpeed * Time.deltaTime);
            rb.velocity = Vel;
            duck_rot.SetY(0);
            duck_rot.SetZ(330);
        }
        else
        {
            Vel = new Vector2((float)-horizonalSpeed * Time.deltaTime, 0);
            rb.velocity = Vel;
            duck_rot.SetY(0);
            duck_rot.SetZ(0);
        }
    }

    void MoveRightAndUp()
    {
        if (flightTime > 0)
        {
            Vel = new Vector2((float)horizonalSpeed * Time.deltaTime, (float)verticalSpeed * Time.deltaTime);
            rb.velocity = Vel;
            duck_rot.SetY(180);
            duck_rot.SetZ(330);
        }
        else
        {
            Vel = new Vector2((float)horizonalSpeed * Time.deltaTime, 0);
            rb.velocity = Vel;
            duck_rot.SetY(180);
            duck_rot.SetZ(0);
        }
    }

    void MoveLeft()
    {
        if (Input.GetButton("Left") && !Input.GetButton("Fly"))
        {
            Vel = new Vector2((float)-horizonalSpeed * Time.deltaTime, 0);
            rb.velocity = Vel;
            duck_rot.SetY(0);
            duck_rot.SetZ(0);

        }
    }

    void MoveRight()
    {
        Vel = new Vector2((float)horizonalSpeed * Time.deltaTime, 0);
        rb.velocity = Vel;
        duck_rot.SetY(180);
        duck_rot.SetZ(0);
    }

    void Fly()
    {
        if (flightTime > 0)
        {
            Vel = new Vector2(0, (float)verticalSpeed * Time.deltaTime);
            rb.velocity = Vel;
            duck_rot.SetZ(330);
        }
        else
        {
            Vel = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Ground")
        // {
        //      Debug.Log("Collided with Ground");
        //     flightTime = 5;
        //     flightStarted = false;
        // }

        if (other.tag == "owl")
        {
            Debug.Log("Collided with owl");
            uncontrollable = true;
            Vel = new Vector2(0, -5);
            duck_rot.SetZ(0);
            fall.Play();
            if (gameManagerScript.hasTwig == true)
            {
                gameManagerScript.hasTwig = false;
            }
        }

        if (other.tag == "Twiggy")
        {
            Debug.Log("Player collided with twiggy");
            StickyScript twiggyStuff = other.gameObject.GetComponent<StickyScript>();
            twiggyStuff.DoTwiggyThings();

        }

        if (other.tag == "Nest" && gameManagerScript.CanBuild())
        {
            Debug.Log("Collided with Nest object");
            buildNestScript.AdvanceNestStage();
        }

        if (other.tag == "Respawn")
        {
            this.transform.position = new Vector2(90, 1);
            if (gameManagerScript.hasTwig == true)
            {
                gameManagerScript.hasTwig = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collided with Ground");
            flightTime = 5;
            flightStarted = false;
            anim.SetBool("inAir", false);
            // inAir = false;
        }
    }
}
