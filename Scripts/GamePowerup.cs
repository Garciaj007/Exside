using UnityEngine;

public class GamePowerup : MonoBehaviour {

    public Sprite heart, bomb, switchControls; //spawn entity in the gamescene, by chosing a powerup;

    private int randomDraw;
    private SpriteRenderer sr;
    private DifficultyManager dm;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        dm = gm.GetComponent<DifficultyManager>();

        sr = this.GetComponent<SpriteRenderer>();
        sr.sortingLayerName = "Entities";
        sr.sortingOrder = 10;

        randomDraw = Random.Range(1, 4);

        switch (randomDraw)
        {
            case 1:
                sr.sprite = heart;
                break;
            case 2:
                sr.sprite = bomb;
                break;
            case 3:
                sr.sprite = switchControls;
                break;
            default:
                sr.sprite = heart;
                break;
        }
    }

    private void LateUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            switch (randomDraw)
            {
                case 1:
                    Debug.Log("Heal");
                    dm.OnHeal();
                    Destroy(this.gameObject);
                    break;
                case 2:
                    Debug.Log("Explosion");
                    dm.OnExplode();
                    Destroy(this.gameObject);
                    break;
                case 3:
                    Debug.Log("SwitchControls");
                    dm.SwitchState();
                    Destroy(this.gameObject);
                    break;
                default:
                    Debug.Log("Heal");
                    dm.OnHeal();
                    Destroy(this.gameObject);
                    break;
            }
        }

        if(collision.name == "City")
        {
            Destroy(this.gameObject);
        }
    }

}
