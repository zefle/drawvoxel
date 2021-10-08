using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPostEvent();
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public float speed_run=.1f;
    
    public bool stop_run;

    public int index_pos=1;

    public OnPostEvent on_detech_boss;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        index_pos=1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        if(Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if(SceneController.instance.in_playing)
            Run();
    }


    public void StopRun()
    {
        stop_run=true;
        PlayerAnimator.instance.Idle();
    }
    public void StartRun()
    {
        stop_run=false;
    }
    public void Run()
    {
        if(stop_run)
            return;
        
        if(!SceneController.instance.in_playing) return;

        transform.position+=new Vector3(0,0,speed_run);
        PlayerAnimator.instance.Run();
    }

    public void MoveLeft()
    {
        if(index_pos<1)
            return;
        if(!SceneController.instance.in_playing) return;
        
        transform.position-= new Vector3(0.281f,0,0);
        index_pos--;
    }
    public  void MoveRight()
    {
        if(index_pos>1)
            return;
        if(!SceneController.instance.in_playing) return;
        
        transform.position-= new Vector3(-0.281f,0,0);
        index_pos++;
    }

    
    public void AttacksBoss()
    {
        attacking_boss = true;
        StartCoroutine(IE_AttacksBoss());
    }
    float _coutTime = 0;
    IEnumerator IE_AttacksBoss()
    {

        while (attacking_boss)
        {
            PlayerAnimator.instance.Attack();
            boss_now.SetHp(-2);
            _coutTime = 0;
            print("attack");
            while (_coutTime<1.5f)
             {
                _coutTime+=Time.deltaTime;

                while (boss_now.hp<0)
                {
                    attacking_boss=false;
                     yield break;
                }
                yield return new WaitForEndOfFrame();
             }
        }
    }
    bool attacking_boss=false;
    BossController boss_now;
    public void SetBossNow(BossController _boss)
    {
        boss_now = _boss;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="detech_boss")
        {
            StopRun();

            if(on_detech_boss!=null)
                on_detech_boss.Invoke();

                
            AttacksBoss();
        }
    }
}
