using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {

    //Getting the player Refrence to switch controls
    private Player player;
    private Image healthBar;
    private Text levelTxt;
    private Utilty util;

    //Get harder over time (AKA Difficulty)
    //change level
    private int level;
    public int difficutyIncrement;

    //Just As it sounds Time that passed, and The time to complete
    private float timePassed, goalTime;

    //Change Enemies Speed Health and Spawn Rate
    private float enemiesSpeedPercentage;
    private float enemiesHealthPercentage;
    private float spawnTimePercentage;

    //Health and heal
    private int health;
    private int heal;

    private static Color startColor = new Color(0, 1, 0.2f, 0.7f);
    private static Color endColor = new Color(1, 0, 0, 0.7f);

	// Use this for initialization
	void Start () {
        util = FindObjectOfType<GameManager>().GetComponent<Utilty>();
        player = FindObjectOfType<Player>();
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        levelTxt = GameObject.Find("Level").GetComponent<Text>();
    
        level = 0;

        spawnTimePercentage = 0.1f;
        enemiesSpeedPercentage = 0.1f;
        enemiesHealthPercentage = 0.1f;

        health = 1000;
        heal = 10;

        healthBar.color = startColor;

        goalTime = 10;
	}
	
	void Update () {
        timePassed = Time.time;
        //levelUpEvery10Seconds
        if(timePassed > goalTime)
        {
            level++;

            spawnTimePercentage += 0.05f;
            enemiesSpeedPercentage += 0.005f;
            enemiesHealthPercentage += 0.1f;

            goalTime = timePassed + 10;
     
            levelTxt.text = "Level " + level.ToString();
            levelTxt.gameObject.transform.localScale.Scale(new Vector3(levelTxt.gameObject.transform.localScale.x + 0.01f, levelTxt.gameObject.transform.localScale.y * 1.1f, levelTxt.gameObject.transform.localScale.z));
            levelTxt.gameObject.transform.Rotate(0, 0, levelTxt.gameObject.transform.rotation.z + 1);
        }

        healthBar.fillAmount = util.Map(health, 0, 1000, 0, 1);
        healthBar.color = Color.Lerp(endColor, startColor, util.Map(health, 0, 1000, 0, 1));

        if (health <= 0)
        {
            //GameOver
            Debug.Log("GameOver");
        }

    }

    //------------------------------------------------------------------//
    //Return Spawn Time Difficulty
    public float GetSpawnTimePercentage()
    {
        return spawnTimePercentage;
    }
    //Return Enemies speed AKA how fast they fall Difficulty
    public float GetEnemiesSpeedPercentage()
    {
        return enemiesSpeedPercentage;
    }
    //Return Enemies health (How much life they will have)
    public float GetEnemiesHealthPercentage()
    {
        return enemiesHealthPercentage;
    }
    //----------------------------------------------------------------//

    public void OnDamage(int damage)
    {
        health = health - damage;
    }

    //method called when player is healed
    public void OnHeal()
    {
        Heal(heal);
    }

    //methos is called as a layer of protection
    private void Heal(int heal)
    {
        if(health + heal > 1000)
        {
            health = 1000;
        } else
        {
            health += heal;
        }
    }

    //Just as its name implies
    public void UpgradeHeal()
    {
        this.heal += 10;
    } 

    //A method that is called when the powerup Switch contoled is activated last for a certain time then deactivates
    public void SwitchState()
    {
        player.SetControlDirection();
    } 

    public void OnExplode()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().OnExplosion();
        }
    }

}
