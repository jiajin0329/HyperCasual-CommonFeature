using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour {
    [SerializeField] private Text fpsText;
    private byte fps;

    private void Update() {
        fps = (byte)(1f / Time.unscaledDeltaTime);
        fpsText.text = fps + " fps";
    }
}
