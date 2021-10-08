using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public bool in_playing =false;

    public List<GameObject> prefabs_audio;

    public List<Sprite> sprites_calculators; 

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IE_Start());
    }

    IEnumerator IE_Start()
    {
        in_playing=false;
        PlayerMove.instance.StopRun();

        yield return new WaitForSeconds(5);
        in_playing=true;
        PlayerMove.instance.StartRun();
    }

    public void SpawnAudio(int _index)
    {
        GameObject _clip = (GameObject)Instantiate(prefabs_audio[_index]);
    }
}
