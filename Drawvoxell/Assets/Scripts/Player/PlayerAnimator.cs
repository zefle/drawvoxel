using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator instance;
    public Animator m_anim;

    int state=0;
    float layer1_weight=0;
    float layer2_weight=0;

    float hurt_motion=0;
    float increase_motion;

    private void Awake() {
        instance=this;
    }
    private void Update() {

        m_anim.SetInteger("state", state);
        m_anim.SetLayerWeight(1, layer1_weight);
        m_anim.SetLayerWeight(2, layer2_weight);

        m_anim.SetFloat("increase_motion", increase_motion);
        m_anim.SetFloat("hurt_motion", hurt_motion);

        if(Input.GetKeyDown(KeyCode.I))
            Increase();
        if(Input.GetKeyDown(KeyCode.H))
            Hurt();
    }
    public void Idle()  
    {
        print("idle");
        state=0;
    }
    public void Run()
    {
        state=1;
    }
    public void Increase()
    {
        StartCoroutine(IE_Increase());
    }
    public void Hurt()
    {
        StartCoroutine(IE_Hurt());
    }

    public void Attack()
    {
        state=2;
        StartCoroutine(IE_BackToIdle());
    }
    IEnumerator IE_BackToIdle()
    {
        // while (state!=2)
        // {
        //      yield break;
        // }
        yield return new WaitForSeconds(1);
        state=0;
    }
    IEnumerator IE_Increase()
    {
        layer1_weight =1;
        increase_motion = 0;
        while (increase_motion<1)
        {
             increase_motion +=Time.deltaTime;

             yield return new WaitForEndOfFrame();
        }
        
        layer1_weight=0;
        increase_motion = 0;
    }
    
    IEnumerator IE_Hurt()
    {
        layer2_weight =1;
        hurt_motion = 0;
        while (hurt_motion<1)
        {
             hurt_motion +=Time.deltaTime*1.2f;

             yield return new WaitForEndOfFrame();
        }
        
        layer2_weight=0;
        hurt_motion = 0;
    }
}
