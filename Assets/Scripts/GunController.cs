using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer = null;
    private Camera camera = null;
    public float offset = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        bool flip = mousePos.x < 0;
        spriteRenderer.flipX = flip;

        transform.position = new Vector3(Mathf.Clamp(mousePos.x+ (flip ? -offset:offset), -8.5f, 8.5f), transform.position.y);
    }
}
