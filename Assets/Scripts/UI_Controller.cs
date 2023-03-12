using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{

    public List<UI_Building> UI_Buildings;

    public List<UI_MarketplaceRow> UI_MarketplaceRows;

    private int currentSettlement;

    public void ShowSettlement(int s){

    }
    
    public void UpdateSettlementUI(int s){

        Settlement settlement = GameManager.instance.Settlements[s];
        
        foreach (UI_Building b in UI_Buildings)
        {
            b.currentQuantityLabel.text = settlement.Buildings[b.BuildingType].ToString();
            b.maxQuantityLabel.text = settlement.ResourceDeposits[b.BuildingType.ResourceDeposit].Quantity.ToString();

            int quality = settlement.ResourceDeposits[b.BuildingType.ResourceDeposit].Quality;
            b.modifier.text = "+" + (quality);

        }

        foreach (UI_MarketplaceRow r in UI_MarketplaceRows)
        {
            r.supplyLabel.text = settlement.Marketplace[r.resourceType].Supply.ToString();
            r.demandLabel.text = settlement.Marketplace[r.resourceType].Demand.ToString();

            float price = settlement.Marketplace[r.resourceType].GetPrice();
            r.priceLabel.text = "$" + price.ToString("F2");
        }
    }
}
