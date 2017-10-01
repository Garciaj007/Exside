using UnityEngine;

public class Explosion : MonoBehaviour {

    private float timefinished;

	// Use this for initialization
	void Start () {
        timefinished = Time.time + 1.0f;
        if (Random.Range(0,2) == 0)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
        } else
        {
            FindObjectOfType<AudioManager>().Play("Explosion2");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= timefinished)
        {
            Destroy(this.gameObject);
        }
	}
}
