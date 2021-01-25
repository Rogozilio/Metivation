using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        other.transform.position = Vector2.MoveTowards(other.transform.position, transform.position, Time.deltaTime);
    }
}
