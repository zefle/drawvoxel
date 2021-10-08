using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCalcu : MonoBehaviour
{
    
    public static PlayerCalcu instance; 
    public TextMeshPro txt;
    public  int m_value=0; 

    public GameObject panel_lost;

    // Update is called once per frame
    private void Awake() {
        instance=this;
    }
    void Update()
    {
            txt.text = m_value+"";
    }
    
    public void Cong(int _value)
    {
        m_value += _value;
        PlayerAnimator.instance.Increase();
        SceneController.instance.SpawnAudio(0);
    }
    public void Tru(int _value)
    {
        m_value -= _value;
        PlayerAnimator.instance.Hurt();
        SceneController.instance.SpawnAudio(1);
    }
    public void Nhan(int _value)
    {
        m_value *= _value;
        PlayerAnimator.instance.Increase();
        SceneController.instance.SpawnAudio(0);
    }
    public void Chia(int _value)
    {
        m_value /= _value;
        PlayerAnimator.instance.Hurt();
        SceneController.instance.SpawnAudio(1);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "pheptinh")
        {   
            PhepTinh pt = col.gameObject.GetComponent<PhepTinh>();

            switch  (pt.m_type)
            {
                case 0: Cong(pt.value); break;
                case 1: Tru(pt.value); break;
                case 2: Nhan(pt.value);break;
                case 3: Chia(pt.value);break;
            }

            if(m_value<0)    
            {   
                m_value = 0;
                panel_lost.SetActive(true);
                GetComponent<PlayerMove>().StopRun();
            }

            pt.DestroyParent();
        }
    }

    public void PlayAgain()
    {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
    }
}
