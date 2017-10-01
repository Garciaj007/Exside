using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Vector2 screenSize;
    private float nextInstanceTime;
    private DifficultyManager dm;
    private Utilty util;

    public GameObject enemy;
    public Vector2 secondsBetweenInstancesMinMax;

	// Use this for initialization
	void Start () {
        util = this.gameObject.GetComponent<Utilty>();
        screenSize = util.GetScreenSize();
        dm = this.gameObject.GetComponent<DifficultyManager>();
        AudioManager.FindObjectOfType<AudioManager>().Play("Music");
	}
	
	// Update is called once per frame
	void Update () {
        SpawnEnemy();
	}

    void SpawnEnemy()
    {
        if (Time.time > nextInstanceTime)
        {
            float currentSession = Mathf.Lerp(secondsBetweenInstancesMinMax.y, secondsBetweenInstancesMinMax.x, dm.GetSpawnTimePercentage());
            nextInstanceTime = Time.time + currentSession;

            Vector2 initPosition = new Vector2(Random.Range(-screenSize.x, screenSize.y), screenSize.y + (enemy.GetComponent<SpriteRenderer>().size.y / 2));

            Instantiate(enemy, initPosition, Quaternion.identity);
        }
    }

}
