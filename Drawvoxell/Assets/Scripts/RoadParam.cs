using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadParam : MonoBehaviour
{
    public bool inView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inView = IsTargetVisible(Camera.main, gameObject);
        if(!IsObjectVisible(Camera.main, gameObject.GetComponent<Renderer>()))
             Destroy(gameObject);
    }
    bool IsTargetVisible(Camera c,GameObject go)
     {
         var planes = GeometryUtility.CalculateFrustumPlanes(c);
         var point = go.transform.position;
         foreach (var plane in planes)
         {
             if (plane.GetDistanceToPoint(point) < 0)
                 return false;
         }
         return true;
     }
     public static bool IsObjectVisible(Camera cam, Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(cam), renderer.bounds);
    }
}
