using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhepTinh : MonoBehaviour
{
    public TextMeshPro txt;
    public int m_type;
    public int value;

    public bool dont_destroy_parent;

    SpriteRenderer m_ren = null;

    void Start()
    {   
        if(transform.childCount>1 && transform.GetChild(1).GetComponent<SpriteRenderer>())
            m_ren = transform.GetChild(1).GetComponent<SpriteRenderer>();
            
        txt=transform.GetChild(0).GetComponent<TextMeshPro>();
        switch  (m_type)
            {
                case 0:
                    txt.text = "+"+" "+value; 
                    if(m_ren!=null)
                        m_ren.sprite = SceneController.instance.sprites_calculators[0];
                
                break;
                case 1: txt.text = "-"+" "+value; 
                    if(m_ren!=null)
                        m_ren.sprite = SceneController.instance.sprites_calculators[1];
                break;
                case 2: txt.text = "x"+" "+value;
                    if(m_ren!=null)
                        m_ren.sprite = SceneController.instance.sprites_calculators[2];
                break;
                case 3: txt.text = ":"+" "+value;
                    if(m_ren!=null)
                        m_ren.sprite = SceneController.instance.sprites_calculators[3];
                break;
            }
    }
    public void SetText()
    {
        txt.text = ""+value; 
    }
    public void DestroyParent()
    {
        if(dont_destroy_parent) return;
        Destroy(transform.parent.gameObject);
    }
}
