using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    [SerializeField] bool touchObject;
    Ray ray;
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] CanDraged canDraged;

    void Update() {
        TouchObject();
        _Drag();
    }

    void TouchObject() {
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(MobileInput.GetTouchStartPosition());
            if(Physics.Raycast(ray, out hit, 100f, layerMask)) {
                touchObject = true;
                canDraged = hit.transform.GetComponent<CanDraged>();
                canDraged.targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(MobileInput.GetTouchStartPosition().x,
                MobileInput.GetTouchStartPosition().y, canDraged.startPosition.z - Camera.main.transform.position.z));
                canDraged.touched = true;
                Debug.Log("touch object");
            }
            Debug.Log("touch");
        }
        else if(Input.GetMouseButtonUp(0)) {
            if(touchObject) {
                touchObject = false;
                canDraged.touched = false;
                canDraged = null;
                Debug.Log("put object");
            }
        }
    }

    void _Drag() {
        if(touchObject) {
            canDraged.targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(MobileInput.GetTouchPosition().x,
                MobileInput.GetTouchPosition().y, canDraged.startPosition.z - Camera.main.transform.position.z));
        }
    }
}
