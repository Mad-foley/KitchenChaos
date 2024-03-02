using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    //can use Transform or GameObject in this scenerio
    [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private Transform counterTopPoint;
    // Start is called before the first frame update
    public void Interact()
    {
        Debug.Log("lol");
        Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPoint);
        tomatoTransform.localPosition = Vector3.zero;
    }
}
