using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public Animator m_anim;
    public int state=0;
    private void Update() {
        m_anim.SetInteger("state", state);
    }

    public void Attack()
    {
        state = 1;
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
        state = 0;
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
    }
}
