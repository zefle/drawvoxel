using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed_run=.1f;
    
    public bool stop_run;

    public int index_pos;  

    void Update()
    {
        Run();

        if(Input.GetKeyDown(KeyCode.V))
            StopRun();
        if(Input.GetKeyDown(KeyCode.B))
            StartRun();

        if(Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        if(Input.GetKeyDown(KeyCode.D))
            MoveRight();
    }

    public void StopRun()
    {
        stop_run=true;
    }
    public void StartRun()
    {
        stop_run=true;
    }
    public void Run()
    {
        if(stop_run)
            return;
        transform.position+=new Vector3(0,0,speed_run);
    }

    public void MoveLeft()
    {
        if(index_pos<1)
            return;
        
        transform.position-= new Vector3(0.281f,0,0);
        index_pos--;
    }
    public  void MoveRight()
    {
        if(index_pos>1)
            return;
        
        transform.position-= new Vector3(-0.281f,0,0);
        index_pos++;
    }
}
