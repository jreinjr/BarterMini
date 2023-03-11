using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement
{
    public int Population {get; protected set;}
    public Dictionary<Resource, ResourceNode> ResourceNodes {get; protected set;}
    public Dictionary<Resource, ResourceBalance> ResourceBalance {get; protected set;}
    public Dictionary<Building, int> Buildings {get; protected set;}

    //public List<Building> Buildings {get; protected set;}

    public void ConstructBuilding(Building building){
        if (building.ResourceNode != null){
            if (Buildings[building] >= ResourceNodes[building.ResourceNode].Quantity){
                return;
            }
        }
        Buildings[building]++;
    }

    public void DestroyBuilding(Building building){
        if (Buildings.ContainsKey(building) == false){
            return;
        }

        if (Buildings[building] <= 0){
            return;
        }

        Buildings[building]--;
    }

    public Settlement(int numPops, int resourceQuantity, int resourceQuality){
        Population = numPops;

        ResourceNodes = new Dictionary<Resource, ResourceNode>();
        ResourceBalance = new Dictionary<Resource, ResourceBalance>();
        Buildings = new Dictionary<Building, int>();

        foreach (var resource in GameManager.instance.Resources)
        {
            ResourceNodes.Add(resource, new ResourceNode());
        }

        foreach (var building in GameManager.instance.Buildings)
        {
            Buildings.Add(building, 0);
        }

        for (int i = 0; i < resourceQuantity; i++)
        {
            Resource randomResource = GameManager.instance.Resources[Random.Range(0, GameManager.instance.Resources.Length)];
            var tempNode = ResourceNodes[randomResource];
            tempNode.Quantity++;
            ResourceNodes[randomResource] = tempNode;
        }

        for (int i = 0; i < resourceQuality; i++)
        {
            Resource randomResource = GameManager.instance.Resources[Random.Range(0, GameManager.instance.Resources.Length)];
            var tempNode = ResourceNodes[randomResource];
            tempNode.Quality++;
            ResourceNodes[randomResource] = tempNode;
        }
    }
}
