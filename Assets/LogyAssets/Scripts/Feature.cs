using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Feature {
    [SerializeField] protected string name;

    virtual public void Initialize() {}
    virtual public void Main() {}
}
