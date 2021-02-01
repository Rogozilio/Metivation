using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Prefabs
{
    private byte                _number;
    private Vector2             _meRespawn;
    private Vector2             _aimRespawn;
    public virtual byte Number { get;}

    public virtual void BuildLevel(bool isDefaultRespawn)
    {
        CalculateRespawn(isDefaultRespawn);
        Instantiate(_prefabs["Me"], _meRespawn, Quaternion.identity);
        Instantiate(_prefabs["Aim"], _aimRespawn, Quaternion.identity);
    }
    private void CalculateRespawn(bool isDefaultRespawn)
    {
        if(isDefaultRespawn)
        {
            _meRespawn  = new Vector2(Screen.width / 2f, Screen.height * 0.1f);
            _aimRespawn = new Vector2(Screen.width / 2f, Screen.height * 0.9f);
        }
        else
        {
            _meRespawn  = new Vector2(Screen.width / 2f, Screen.height * 0.9f);
            _aimRespawn = new Vector2(Screen.width / 2f, Screen.height * 0.1f);
        }
    }
}
