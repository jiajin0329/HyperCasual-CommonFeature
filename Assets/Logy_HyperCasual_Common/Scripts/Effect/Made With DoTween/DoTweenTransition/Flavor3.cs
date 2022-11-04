using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flavor3 : DoTweenTransition {
    [SerializeField] float move_cost_time;
    [SerializeField] int image_amount;
    [SerializeField] float interval_delay;
    [SerializeField] RectTransform image;
    [SerializeField] GameObject generate_point;

    RectTransform[] images;

    public void TransitionIn () {
        StartCoroutine(DelayTransitionIn());
    }
    IEnumerator DelayTransitionIn() {
        generate_point.SetActive(true);

        for(int i = 0; i < image_amount; i++) {
            images[i].DOLocalMoveY(0f, move_cost_time).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(interval_delay);
        }
    }

    public void TransitionOut() {
        StartCoroutine(DelayTransitionOut());
    }
    IEnumerator DelayTransitionOut() {
        for(int i = image_amount-1; i >= 0; i--) {
            images[i].DOLocalMoveY(-Screen.height, move_cost_time).SetEase(Ease.InQuad);
            yield return new WaitForSeconds(interval_delay);
        }
        yield return new WaitForSeconds(move_cost_time);
        End(0f);
    }

    public override float CostTime() {
        return move_cost_time + interval_delay * image_amount;
    }

    void Start() {
        PlayEvent.AddListener(TransitionIn);
        FinishEvent.AddListener(TransitionOut);
        GenerateImage();
    }

    void GenerateImage() {
        images = new RectTransform[image_amount];

        //generate image and setting
        for(int i = 0; i < image_amount; i++) {
            float interval_width = 1f/image_amount;

            images[i] = Instantiate(image, generate_point.transform);
            images[i].anchorMax = new Vector2(1-interval_width*i, images[i].anchorMax.y);
            images[i].anchorMin = new Vector2(1-interval_width*(i+1), images[i].anchorMin.y);

            images[i].localPosition += new Vector3(0f, Screen.height, 0f);
        }
    }
}
