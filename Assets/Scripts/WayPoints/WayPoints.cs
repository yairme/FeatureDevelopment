using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        Vector3 position = transform.position;
        position.y += 0.5f;
        return position;
    }
}
