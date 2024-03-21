using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
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
