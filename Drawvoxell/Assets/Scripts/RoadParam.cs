using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadParam : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(!IsObjectVisible(Camera.main, gameObject.GetComponent<Renderer>()))
             Destroy(gameObject);
    }
     public static bool IsObjectVisible(Camera cam, Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(cam), renderer.bounds);
    }
}
