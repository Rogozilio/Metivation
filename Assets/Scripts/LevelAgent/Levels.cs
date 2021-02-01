using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : Level
{
    public override byte Number { get => 0; }
}
public class Level1 : Level
{
    public override byte Number { get => 1; }
    public override void BuildLevel(bool isDefaultRespawn)
    {
        base.BuildLevel(isDefaultRespawn);
        Instantiate(_prefabs["Block"], new Vector2(Screen.width / 2 - 40, Screen.height / 2), Quaternion.identity);
        Instantiate(_prefabs["Block"], new Vector2(Screen.width / 2 + 40, Screen.height / 2), Quaternion.identity);
    }
}
