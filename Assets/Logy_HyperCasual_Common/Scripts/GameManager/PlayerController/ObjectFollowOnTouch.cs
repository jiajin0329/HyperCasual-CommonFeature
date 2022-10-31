using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowOnTouch : MonoBehaviour {
    [SerializeField] bool enable;
    [SerializeField] float distance;


    public void On() {
        StartCoroutine(_On());
    }
    IEnumerator _On() {
        enable = true;
        while(enable) {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
            yield return new WaitForEndOfFrame();
        }
    }

    public void Off() {
        enable = false;
    }
}
