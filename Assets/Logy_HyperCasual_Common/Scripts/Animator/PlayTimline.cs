using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimline : MonoBehaviour {
    [SerializeField] PlayableDirector playableDirector;

    public void Play() {
        playableDirector.Play();
    }
}
