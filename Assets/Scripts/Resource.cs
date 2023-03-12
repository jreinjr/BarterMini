
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Resource", menuName = "Data/Resource")]
public class Resource : ScriptableObject {
    [SerializeField] Building _productionBuilding;
    public Building ProductionBuilding {get => _productionBuilding; }

}