using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction : MonoBehaviour
{
    public Animator m_anim;

    public int state;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        m_anim.SetInteger("state", state);
    }

    public void Attack()
    {
        state = 1;
        StartCoroutine(IE_BackIdle(1));
    }
    public void Die()
    {
        StartCoroutine(IE_Die());
    }

    IEnumerator IE_BackIdle(float _t)
    {
        yield return new WaitForSeconds(_t);
        state = 0;
    }
    IEnumerator IE_Die()
    {
        state = 2;
        yield return new WaitForSeconds(1);
        //Destroy(transform.parent.gameObject);
    }
}
