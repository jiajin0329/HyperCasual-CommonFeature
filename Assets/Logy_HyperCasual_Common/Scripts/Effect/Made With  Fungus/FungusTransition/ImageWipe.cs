using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageWipe : FungusTransition {
    [SerializeField] Vector3 start_position;

    public void Init() {
        flowchart.GetVariable<Fungus.Vector3Variable>("start_position").Value = start_position;
        flowchart.GetVariable<Fungus.Vector3Variable>("end_position").Value = -start_position;
    }
}