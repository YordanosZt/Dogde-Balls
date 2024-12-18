using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed;
    public float maxLifeTime = 30f;

    private SpriteRenderer _renderer;
    private Rigidbody2D rb;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();  
        rb = GetComponent<Rigidbody2D>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer.color = RandomColor();

        transform.localScale = Vector3.one * size;

        rb.mass = size;
    }

    private Color RandomColor()
    {
        string[] hex = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f" };
        string hexCode = "#";

        Color randomColor;

        for (int i = 0; i < 6; i++)
        {
            hexCode += hex[Random.Range(0, hex.Length)];
        }

        ColorUtility.TryParseHtmlString(hexCode, out randomColor);

        return randomColor;
    }

    public void SetTrajectory(Vector2 direction){
        rb.AddForce(direction * speed);

        Destroy(this.gameObject, maxLifeTime);
    }
}
