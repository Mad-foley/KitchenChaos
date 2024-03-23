using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    //cutting progress bar event
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs {
        public float progressNormalized;
    }

    public event EventHandler OnCut;

    [SerializeField] private CuttingRecipeSO[] cuttingReceipeSOArray;

    private int cuttingProgress;
    public override void Interact(Player player)
    {
         if (!HasKitchenObject()){
            if(player.HasKitchenObject()){
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    cuttingProgress = 0;

                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    //fire off cutting progress event
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs {
                        //remember to cast as float
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });
                } else {
                }

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
    public override void InteractAlternate(Player player)
    {
         if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())){
            cuttingProgress++;

            OnCut?.Invoke(this,EventArgs.Empty);

            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs {
                //remember to cast as float
                progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
            });

            if(cuttingProgress >= cuttingRecipeSO.cuttingProgressMax){
                KitchenObjectSO outputKitchenObjectSO = GetOutputFotInput(GetKitchenObject().GetKitchenObjectSO());
                //destroy object and spawn sliced object
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        } else {

        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        return cuttingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputFotInput(KitchenObjectSO inputKitchenObjectSO){
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (cuttingRecipeSO != null) {
            return cuttingRecipeSO.output;
        } else {
            return null;
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO){
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingReceipeSOArray){
            if(cuttingRecipeSO.input == inputKitchenObjectSO){
                return cuttingRecipeSO;
            }
        }
        return null;
    }

}
