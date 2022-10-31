using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterSelect : MonoBehaviour {
    public static byte id;

    [SerializeField] bool selected;
    [SerializeField] CanSelect canSelect;
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject hint;
    [SerializeField] GameObject chooseButton;
    [SerializeField] byte characterID;

    float per;
    Vector3 startLocalPosition;
    Vector3 differencePosition;
    float startLocalAngleY;
    bool turn;

    void Awake() {
        canSelect.Select += () => {
            StartCoroutine(Select());
        };

        canSelect.Cancel += () => {
            StartCoroutine(Cancel());
        };

        startLocalPosition = transform.localPosition;
        differencePosition = new Vector3(0f, startLocalPosition.y, 0f) - startLocalPosition;
        startLocalAngleY = transform.localEulerAngles.y;
    }

    IEnumerator Select() {
        selected = true;
        hint.SetActive(false);
        chooseButton.SetActive(false);
        id = characterID;
        Debug.Log("Select");

        StartCoroutine(SelectMove());

        yield return null;
    }
    
    IEnumerator Cancel() {
        selected = false;
        Debug.Log("Cancel");

        StartCoroutine(CancelMove());

        yield return null;
    }

    IEnumerator SelectMove() {
        if(turn) transform.DOLocalRotate(new Vector3(0f, startLocalAngleY, 0f), 0.5f);
        while(selected) {
            per += Time.deltaTime;
            if(per > 1f) {
                per = 1f;

                chooseButton.SetActive(true);
                break;
            }
            
            SetPosition();

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Select Move End");
    }

    IEnumerator CancelMove() {
        turn = true;
        transform.DOLocalRotate(new Vector3(0f, startLocalAngleY + 180f, 0f), 0.5f);
        while(!selected) {
            per -= Time.deltaTime;
            if(per < 0f) {
                per = 0f;
                turn = false;
                transform.DOLocalRotate(new Vector3(360f, startLocalAngleY, 360f), 0.5f);
                break;
            }

            SetPosition();

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Cancel Move End");
    }

    void SetPosition() {
        transform.localPosition = startLocalPosition + differencePosition * speed * per;
    }
}
