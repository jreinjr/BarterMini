using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Data/Building")]
public class Building : ScriptableObject {

    [SerializeField] Resource _resourceNode;
    public Resource ResourceNode {get => _resourceNode;}
}