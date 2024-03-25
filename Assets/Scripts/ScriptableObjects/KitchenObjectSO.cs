using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

//uses scriptable object
//Scriptable objects super important to get down
public class KitchenObjectSO : ScriptableObject
{
    //scriptable object should either be public or has a get function
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
