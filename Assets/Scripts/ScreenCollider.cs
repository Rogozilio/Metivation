using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    private EdgeCollider2D  _col;
    private Vector2[]       _edgeScreen;
    void Start()
    {
        transform.position  = new Vector3(0, 0, transform.position.z);
        Vector2 minXY       = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 minXmaxY    = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        Vector2 maxXminY    = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 maxXY       = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _edgeScreen         = new Vector2[5] 
        { 
            minXY, 
            minXmaxY, 
            maxXY, 
            maxXminY, 
            minXY
        };
        _col        = GetComponent<EdgeCollider2D>();
        _col.points = _edgeScreen;
    }
}
