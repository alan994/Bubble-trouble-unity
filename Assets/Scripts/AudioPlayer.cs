using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        GameObject[] allAudioObjects = GameObject.FindGameObjectsWithTag(NameHelper.TagAudio);
        if(allAudioObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
