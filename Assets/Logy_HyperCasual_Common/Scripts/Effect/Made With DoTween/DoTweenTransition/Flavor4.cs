using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flavor4 : DoTweenTransition {
    [SerializeField] float move_cost_time;
    [SerializeField] int image_amount;
    [SerializeField] float interval_delay;
    [SerializeField] float angle;
    enum Type {type1, type2}
    [SerializeField] Type type;
    [SerializeField] RectTransform image;
    [SerializeField] GameObject generate_point;

    RectTransform[] images;
    

    public void TransitionIn (float wait) {
        StartCoroutine(DelayTransitionIn(wait));
    }
    IEnumerator DelayTransitionIn(float wait) {
        yield return new WaitForSeconds(wait);
        generate_point.SetActive(true);

        for(int i = 0; i < image_amount; i++) {
            images[i].DOLocalMoveX(0f, move_cost_time).SetEase(Ease.OutQuad);
        }
    }

    public void TransitionOut(float wait) {
        StartCoroutine(DelayTransitionOut(wait));
    }
    IEnumerator DelayTransitionOut(float wait) {
        yield return new WaitForSeconds(wait);
        for(int i = image_amount-1; i >= 0; i--) {
            images[i].DOLocalMoveX(-JudgeLeftRight(i)*Screen.width, move_cost_time).SetEase(Ease.InQuad);
        }
        yield return new WaitForSeconds(move_cost_time);
        End(0f);
    }

    public override float CostTime() {
        return move_cost_time + interval_delay * image_amount;
    }



    void Start() {
        generate_point.transform.localEulerAngles = new Vector3(0f, 0f, angle);
        GenerateImage();
    }

    void GenerateImage() {
        images = new RectTransform[image_amount];
        
        //generate image and setting
        for(int i = 0; i < image_amount; i++) {
            float interval_width = 1f/image_amount;

            images[i] = Instantiate(image, generate_point.transform);
            images[i].anchorMax = new Vector2(1f, 1-interval_width*i);
            images[i].anchorMin = new Vector2(0f, 1-interval_width*(i+1));

            images[i].localPosition += new Vector3(JudgeLeftRight(i)*Screen.width, 0f, 0f);
        }
    }
    float JudgeLeftRight(int index) {
        if(index % 2 > 0)
            return -1;
        else
            return 1;
    }
}
