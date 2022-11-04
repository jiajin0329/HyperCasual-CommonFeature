using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeshRenenderColor : MonoBehaviour {
    [SerializeField] new MeshRenderer renderer;
    [SerializeField] Color targetColor;
    Color start_color;

    void Start() {
        start_color = renderer.material.color;
    }

    public void TurnStartColor(float duration) {
        DOTween.Kill(renderer.material);
        renderer.material.DOColor(start_color, duration);
    }

    public void TurnColor(float duration) {
        DOTween.Kill(renderer.material);
        renderer.material.DOColor(targetColor, duration);
    }
}