using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Camera camera = null;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Cursor.visible = mousePos.x < -8.5f ||
                         mousePos.x > 8.5f ||
                         mousePos.y < -3.5f ||
                         mousePos.y > 4.5f;

        transform.position = new Vector3(Mathf.Clamp(mousePos.x, -8.5f, 8.5f), Mathf.Clamp(mousePos.y, -3.5f, 4.5f));
    }
}
