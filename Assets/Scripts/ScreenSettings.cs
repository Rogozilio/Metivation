using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    private EdgeCollider2D  _col;
    private Vector2[]       _edgeScreen;
    private Camera          _camera;
    void Start()
    {
        _col    = GetComponent<EdgeCollider2D>();
        _camera = GetComponent<Camera>();
        ScreenOptions();
        ScreenCollider();
    }
    private void ScreenOptions()
    {
        _camera.aspect              = (float)Screen.width / Screen.height;
        _camera.orthographicSize    = Screen.height / 2;
        _camera.transform.position  = new Vector3(Screen.width / 2, Screen.height / 2, transform.position.z);
    }
    private void ScreenCollider()
    {
        Vector2 minXY       = _camera.ViewportToWorldPoint(new Vector2(-0.5f, -0.5f));
        Vector2 minXmaxY    = _camera.ViewportToWorldPoint(new Vector2(-0.5f, 0.5f));
        Vector2 maxXminY    = _camera.ViewportToWorldPoint(new Vector2(0.5f, -0.5f));
        Vector2 maxXY       = _camera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        _edgeScreen         = new Vector2[]
        {
            minXY,
            minXmaxY,
            maxXY,
            maxXminY,
            minXY
        };
        _col = GetComponent<EdgeCollider2D>();
        _col.points = _edgeScreen;
    }
}
