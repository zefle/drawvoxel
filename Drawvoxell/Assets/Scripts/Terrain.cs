
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public List<Material> mats;
    public GameObject cube;

    float oldScale_z=0;
    float oldPos_z=0;

    float coutTime=0;

    private void Start() {
        Spawn();
    }
    void Update()
    {
        OnSpawn();
    }
    public void OnSpawn()
    {
        if(!SceneController.instance.in_playing)
           return;

        if(coutTime>.7f)
        {
            Spawn();
            coutTime=0;
        }
        else
        {
            coutTime += Time.deltaTime;
        }
    }

    public void Spawn()
    {
        GameObject go= (GameObject)Instantiate(cube, transform);
        
        int i= UnityEngine.Random.Range(0, mats.Count);
        
        float newScale_z = Random.Range(3,10);
        float newPos_z = oldScale_z/2 + newScale_z/2+ oldPos_z;

        go.GetComponent<Renderer>().material = mats[i];

        go.transform.localScale= new Vector3(1,1,oldScale_z);
        go.transform.position= new Vector3(0,0,oldPos_z);

        oldPos_z = newPos_z;
        oldScale_z= newScale_z;

        go.SetActive(true);
    }

}
