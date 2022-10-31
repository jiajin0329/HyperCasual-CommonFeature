using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour {
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Animator animator;
    [SerializeField] string animation_name;
    public void SetActiveTrue(int i) {
        gameObjects[i].SetActive(true);
    }
    public void SetActiveFalse(int i) {
        gameObjects[i].SetActive(false);
    }

    public IEnumerator PlayAnimation(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        animator.Play(animation_name);
    }
}
