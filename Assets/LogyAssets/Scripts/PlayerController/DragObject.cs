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
        if(Mobile_Input.Get_onTouchDown()) {
            ray = Camera.main.ScreenPointToRay(Mobile_Input.Get_TouchStartPosition());
            if(Physics.Raycast(ray, out hit, 100f, layerMask)) {
                touchObject = true;
                canDraged = hit.transform.GetComponent<CanDraged>();
                canDraged.targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Mobile_Input.Get_TouchStartPosition().x,
                Mobile_Input.Get_TouchStartPosition().y, canDraged.startPosition.z - Camera.main.transform.position.z));
                canDraged.touched = true;
                Debug.Log("touch object");
            }
            Debug.Log("touch");
        }
        else if(Mobile_Input.Get_onTouchUp()) {
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
            canDraged.targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Mobile_Input.Get_TouchPosition().x,
                Mobile_Input.Get_TouchPosition().y, canDraged.startPosition.z - Camera.main.transform.position.z));
        }
    }
}
