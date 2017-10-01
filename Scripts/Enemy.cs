using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour{
    //Other gameobjects and assets;
    private Utilty util;
    private DifficultyManager dm;

    public GameObject explosion;
    public GameObject powerUp;

    //Variables that evolve from Min to Max;
    public Vector2 speedMinMax;
    public Vector2 enemyHealthMinMax;

    //speed and health for the enemy
    //public Image healthBar;
    private float health;
    private float startHealth;
    private float speed;
 

    //Starting and ending color
    //private static Color startColor = new Color(0, 1, 0.2f, 0.7f);
    //private static Color endColor = new Color(1, 0, 0, 0.7f);

    // Use this for initialization
    void Start () {
        //find the utility class component
        util = FindObjectOfType<GameManager>().GetComponent<Utilty>();

        //get the dificulty manager
        dm = FindObjectOfType<GameManager>().GetComponent<DifficultyManager>();

        //get the speed for the enemy
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, dm.GetEnemiesSpeedPercentage());

        //get the health for the enemy
        startHealth = Mathf.Lerp(enemyHealthMinMax.x, enemyHealthMinMax.y, dm.GetEnemiesHealthPercentage());
        health = startHealth;

        /*
        //get the HealthBar
        healthBar = GameObject.Find("EnemyHealthBar").GetComponent<Image>();
        healthBar.fillAmount = util.Map(health, 0, health, 0, 1);
        healthBar.color = startColor;
        */
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //checks if the health is less or equal to 0
        /*
        if (healthBar != null)
        {
            healthBar.fillAmount = util.Map(health, 0, health, 0, 1);
            healthBar.color = Color.Lerp(endColor, startColor, util.Map(health, 0, startHealth, 0, 1));
        }
        */

        if (health <= 0)
        {
            //update score
            
            //spawn explosion
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            //Spawn Powerup
            if (Random.Range(1, 4) == 3)
            {
                Instantiate(powerUp, this.transform.position, Quaternion.identity);
            }
            //Destroy itself
            Destroy(this.gameObject);
        }

       
	}

    public void OnDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "City")
        {
            //Update Score
            dm.OnDamage(10);
            //Spawn Explosion
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            //Destroy This 
            Destroy(this.gameObject);
        }
    }

    public void OnExplosion()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
