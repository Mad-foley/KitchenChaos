using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//not a class but an interface, no function implementation
public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectfollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
}
