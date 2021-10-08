using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float distance_to_detect_player;


    private void Update() {
        if(DetectPlayer())
            GetComponent<EnemyAction>().Attack();
    }


    public bool DetectPlayer()
    {
        if(Vector3.Distance(transform.position, PlayerMove.instance.transform.position)< distance_to_detect_player)
            return true;
        return false;
    }
    float _value=0;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            _value = (PlayerCalcu.instance.m_value - GetComponent<PhepTinh>().value);
            print(PlayerCalcu.instance.m_value+"         "+   GetComponent<PhepTinh>().value);
            print(_value);

            if(_value>=0)
                GetComponent<EnemyAction>().Die(); 
        }
    }
}
