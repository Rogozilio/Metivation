using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    private bool _isEnable;
    private Text _log;

    public void Start()
    {
        _log = GetComponent<Text>();
        _isEnable = false;
    }

    public void Control(Me me)
    {
        if (_isEnable)
        {
            _log.text = "CountTouch = " + Input.touchCount;
            _log.text += "\n FullPos = (" + (me.Pos.x*me.EdgePos).ToString("F2") + "," + (me.Pos.y*me.EdgePos).ToString("F2") + ")";
            _log.text += "\n Pos = (" + me.Pos.x.ToString("F2") + "," + me.Pos.y.ToString("F2") + ")";
        }
    }
}
