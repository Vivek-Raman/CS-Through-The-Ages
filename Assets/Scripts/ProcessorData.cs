using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ProcessorData", fileName = "ProcessorData", order = 0)]
public class ProcessorData : ScriptableObject
{
    public GameObject prefab;
    public Sprite image;
    public string title;
    public string description;
}
