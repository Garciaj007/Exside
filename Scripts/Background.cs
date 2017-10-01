using UnityEngine;

public class Background : MonoBehaviour {

    public float backgroundSpeed;

    public Vector3 startPosition;
    public Vector3 endPosition;
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.down * backgroundSpeed * Time.deltaTime);

        if(this.transform.position.y <= endPosition.y)
        {
            Instantiate(this.gameObject, startPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(endPosition,"Background");
        Gizmos.DrawIcon(startPosition, "Background");
    }
}
