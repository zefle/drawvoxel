using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public int count_spawn_enemy = 0;

    public bool focus_target;

    public GameObject enemy, boss;

    float coutTime=0;
    void Update()
    {
        FocusTarget();
        
        SpawnsEnemy();

    }
    public void SpawnsEnemy()
    {
        if(!SceneController.instance.in_playing)
            return;
        if(count_spawn_enemy<6)
        {
            if(coutTime>5)
            {
                SpawnEnemy();
                coutTime=0;
            }
            else
            {
                coutTime+=Time.deltaTime;
            }
        }
    }

    public void FocusTarget()
    {
        if(!focus_target) return;
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }

    public void SpawnEnemy()
    {
        GameObject go= (GameObject)Instantiate( count_spawn_enemy<5? enemy:boss, null);
        go.transform.position = new Vector3(0,0.61f, transform.position.z+13);

        count_spawn_enemy++;
    }
}
