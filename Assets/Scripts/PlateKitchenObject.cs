using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectsSO kitchenObjectSO;
    }

    //player tabaða tomato yerine tomato slices koymalý
    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectsSOList;

    //plate diðer objelerden farklý olarak birden fazla yemeði tutabilir bu yüzden list kullanýyoruz
    private List<KitchenObjectsSO> kitchenObjectSOList;
    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectsSO>();
    }
    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectSO)
    {
        if (!validKitchenObjectsSOList.Contains(kitchenObjectSO))
        {
            //this ingredient is not valid for the plate
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //already have this ingredient
            return false;
        }else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
    }
    public List<KitchenObjectsSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
