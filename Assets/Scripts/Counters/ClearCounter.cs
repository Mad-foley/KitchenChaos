using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//extend with interface
public class ClearCounter : BaseCounter
{


    //can use Transform or GameObject in this scenerio
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject()){
            if(player.HasKitchenObject()){
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //player has nothing
            }
        } else {
            if(player.HasKitchenObject()){

            } else {
                //player not carrying anything
                //give to player
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
