using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    private Text _log;

    public void Start()
    {
        _log = GetComponent<Text>();
    }

    public void Control(Control me)
    {
        _log.text = "CountTouch = " + Input.touchCount;
        _log.text += "\n FullPos = (" + (me.Pos.x*me.EdgePos).ToString("F2") + "," + (me.Pos.y*me.EdgePos).ToString("F2") + ")";
        _log.text += "\n Pos = (" + me.Pos.x.ToString("F2") + "," + me.Pos.y.ToString("F2") + ")";
    }
}
