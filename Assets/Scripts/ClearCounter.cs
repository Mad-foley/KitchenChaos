using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//extend with interface 
public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{


    //can use Transform or GameObject in this scenerio
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    // Start is called before the first frame update

    private KitchenObject kitchenObject;


    public void Interact(Player player)
    {
        if(kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        } else
        {
            //give object to player
            kitchenObject.SetKitchenObjectParent(player);
        }

    }

    public Transform GetKitchenObjectfollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
