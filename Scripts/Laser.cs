using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float speed = 1.0f;
    private Transform laserTransform;
    private Utilty util;

    public Vector2 damage;

	// Use this for initialization
	void Start () {
        util = FindObjectOfType<GameManager>().GetComponent<Utilty>();
        laserTransform = this.GetComponent<Transform>();
        AudioManager.FindObjectOfType<AudioManager>().Play("Laser");
	}
	
	// Update is called once per frame
	void Update () {
        laserTransform.Translate(Vector3.up * speed * Time.deltaTime);

        //if a laser passes the bounds of the camera
        if(this.transform.position.y >= util.GetScreenSize().y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damage the enemy
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().OnDamage(Random.Range(damage.x, damage.y));
            Destroy(this.gameObject);
        }
        //destroy itself
    }
}

