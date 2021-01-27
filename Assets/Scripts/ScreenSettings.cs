using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.aspect = (float)Screen.width / Screen.height;
    }
}
