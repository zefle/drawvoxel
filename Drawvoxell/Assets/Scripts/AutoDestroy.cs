using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time_life=1;

    private void OnEnable() {
        Destroy(gameObject, time_life);
    }
}
