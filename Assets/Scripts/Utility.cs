using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Vector3 GetWorldPointFromScreenPoint(Vector2 screePoint,float height)
    {
        Ray ray = Camera.main.ScreenPointToRay(screePoint);
        Plane plane = new Plane(Vector3.up,new Vector3(0,height,0));
        float distance;
        if (plane.Raycast(ray, out distance)) ;
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}
