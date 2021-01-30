using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Prefabs
{
    private byte                _number;
    private bool                _isDefaultRespawn;
    private Vector2             _meRespawn;
    private Vector2             _aimRespawn;
    public virtual byte Number { get;}

    public virtual void buildLevel()
    {
        CalculateRespawn();
        Instantiate(_prefabs["Me"], _meRespawn, Quaternion.identity);
        Instantiate(_prefabs["Aim"], _aimRespawn, Quaternion.identity);
    }
    private void CalculateRespawn()
    {
        if(_isDefaultRespawn)
        {
            _meRespawn  = new Vector2(Screen.width / 2f, Screen.height * 0.05f);
            _aimRespawn = new Vector2(Screen.width / 2f, Screen.height * 0.95f);
        }
        else
        {
            _meRespawn  = new Vector2(Screen.width / 2f, Screen.height * 0.95f);
            _aimRespawn = new Vector2(Screen.width / 2f, Screen.height * 0.05f);
        }
    }
}
