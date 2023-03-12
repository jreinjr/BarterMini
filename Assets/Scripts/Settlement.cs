using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Settlement
{
    public int IdlePopulation {get; protected set;}
    public Dictionary<Resource, ResourceNode> ResourceDeposits {get; protected set;}
    public Dictionary<Resource, ResourceBalance> Marketplace {get; protected set;}
    public Dictionary<Building, int> Buildings {get; protected set;}

    public void ConstructBuilding(Building building){
        if (building.ResourceDeposit != null){
            if (Buildings[building] >= ResourceDeposits[building.ResourceDeposit].Quantity){
                return;
            }
        }
        Buildings[building]++;
        IdlePopulation--;

        UpdateMarketplace();
    }

    public void DestroyBuilding(Building building){
        if (Buildings.ContainsKey(building) == false){
            return;
        }

        if (Buildings[building] <= 0){
            return;
        }

        Buildings[building]--;
        IdlePopulation++;

        UpdateMarketplace();
    }

    public Settlement(int numPops, int resourceQuantity, int resourceQuality){
        IdlePopulation = numPops;

        ResourceDeposits = new Dictionary<Resource, ResourceNode>();
        Marketplace = new Dictionary<Resource, ResourceBalance>();
        Buildings = new Dictionary<Building, int>();

        foreach (var resource in GameManager.instance.Resources)
        {
            ResourceDeposits.Add(resource, new ResourceNode());
            Marketplace.Add(resource, new ResourceBalance());
        }

        foreach (var building in GameManager.instance.Buildings)
        {
            Buildings.Add(building, 0);
        }

        for (int i = 0; i < resourceQuantity; i++)
        {
            Resource randomResource = GameManager.instance.Resources[Random.Range(0, GameManager.instance.Resources.Length)];
            var tempNode = ResourceDeposits[randomResource];
            tempNode.Quantity++;
            ResourceDeposits[randomResource] = tempNode;
        }

        for (int i = 0; i < resourceQuality; i++)
        {
            Resource randomResource = GameManager.instance.Resources[Random.Range(0, GameManager.instance.Resources.Length)];
            var tempNode = ResourceDeposits[randomResource];
            tempNode.Quality++;
            ResourceDeposits[randomResource] = tempNode;
        }

        UpdateMarketplace();
    }

    public void UpdateMarketplace(){
        foreach (Resource resource in Marketplace.Keys)
        {
            Marketplace[resource].Supply = Buildings[resource.ProductionBuilding] * (1 + ResourceDeposits[resource].Quality * 0.2f) + IdlePopulation;
            Marketplace[resource].Demand = IdlePopulation;
        }
    }
}
