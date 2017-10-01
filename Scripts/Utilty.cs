using UnityEngine;

public class Utilty : MonoBehaviour {

    private Vector2 screenSize;

    private void Awake()
    {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Use this for initialization
    void Start () {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

    // Update is called once per frame
    void Update () {
		
	}

    private void LateUpdate()
    {
        screenSize.Set(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    public Vector2 GetScreenSize()
    {
        return screenSize;
    }

    public float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
