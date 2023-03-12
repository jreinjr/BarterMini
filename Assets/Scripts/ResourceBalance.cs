using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBalance
{
    const float BASE_RESOURCE_PRICE = 10f;
    public float Supply;
    public float Demand;
    public float GetPrice(){
        float price = BASE_RESOURCE_PRICE * Demand / Supply;
        return price;
    }
}
