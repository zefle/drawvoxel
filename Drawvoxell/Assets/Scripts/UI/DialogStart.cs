using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogStart : MonoBehaviour
{
    public Text txt_1, txt_2;

    private void OnEnable() {
        StartCoroutine(IE_Script());
    }

    float coutTime=0;
    IEnumerator IE_Script()
    {
        coutTime = 4; 
        txt_1.text = "READY";
        txt_2.text = "";
        yield return new WaitForSeconds(1);

        while (coutTime>1)
        {
             coutTime -= Time.deltaTime;
             txt_2.text = ""+ (int)coutTime;

             yield return new WaitForEndOfFrame();
        }
        txt_1.text = "GO!";
        txt_2.text = "";
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
