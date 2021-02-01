using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prefabs : MonoBehaviour
{
    protected Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>()
    {
        { "Me"   , Resources.Load<GameObject>("Prefabs/Me") },
        { "Aim"  , Resources.Load<GameObject>("Prefabs/Aim")},
        { "Block", Resources.Load<GameObject>("Prefabs/Block")},
    };
}
