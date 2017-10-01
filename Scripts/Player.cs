using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Vector2 screenSize;
    private Utilty util;

    private Rigidbody2D player;
    private float direction;
    private float size;
    public float speed;
    private bool switchState;

    public GameObject laser;
    private Vector3 laserposition, laserOffset;

	// Use this for initialization
	void Start () {
        util = FindObjectOfType<GameManager>().GetComponent<Utilty>();
        screenSize = util.GetScreenSize();
        switchState = false;
 
        player = this.GetComponent<Rigidbody2D>();
        direction = 0;
        size = player.GetComponent<SpriteRenderer>().size.x / 2;
        laserOffset = new Vector3(0, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if(switchState == true)
        {
            direction = -(Input.GetAxisRaw("Horizontal"));
        } else
        {
            direction = Input.GetAxisRaw("Horizontal");
        }
        
        Vector2 movement = new Vector2(direction * speed, 0);
        player.AddForce(movement);

        if(player.position.x >= screenSize.x)
        {
            player.MovePosition(new Vector2(-screenSize.x + size, player.position.y));
        }

        if(player.position.x <= -screenSize.x)
        {
            player.MovePosition(new Vector2(screenSize.x - size, player.position.y));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            laserposition = this.gameObject.transform.position + laserOffset;
            Instantiate(laser, laserposition, Quaternion.identity);
        }
    }

    public void SetControlDirection()
    {
         switchState = !switchState;
    }

  
}
