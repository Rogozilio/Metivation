using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.aspect = (float)Screen.width / Screen.height;
        _camera.orthographicSize = Screen.height / 2;
        _camera.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    //void Update()
    //{
    //    _camera.aspect = (float)Screen.width / Screen.height;
    //    _camera.orthographicSize = Screen.height / 2;
    //}
}
