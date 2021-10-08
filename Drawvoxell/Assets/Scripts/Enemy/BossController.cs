using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{   
    BossAction m_action;
    public Image img_hp;
    public bool fighting=false;

    public int damage=10;
    public int maxHp=10;
    public int hp=10;
    void Start()
    {
        
        PlayerMove.instance.on_detech_boss += OnDetechPlayer;
        m_action= GetComponent<BossAction>();
        img_hp.fillAmount = 1;
        hp=maxHp;
    }
    public void SetHp(int _value)
    {
        hp+=_value;

        if(hp<=0)
        {
            fighting = false;
            m_action.Die();
        }
        float _i = (float)hp/maxHp;
        img_hp.fillAmount = _i;

    }

    void OnDetechPlayer()
    {
        fighting=true;
        PlayerMove.instance.SetBossNow(this);
        StartCoroutine(IE_Fighting());
    }

    float _coutTime=0;
    IEnumerator IE_Fighting()
    {
        while (fighting)
        {
            
            PlayerCalcu.instance.Tru(damage);
            m_action.Attack();
             while (_coutTime<2)
             {
                _coutTime+=Time.deltaTime;

                while (!fighting)
                {
                     yield break;
                }
                yield return new WaitForEndOfFrame();
             }
            _coutTime = 0;
        }
    }
}
