using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    // [Header("References")]
    // [SerializeField] UI_Controller ui_Controller;

    [Header("Game Settings")]
    [SerializeField] int numSettlements = 12;

    [Header("Settlement Settings")]
    [SerializeField] int popPerSettlement = 50;
    [SerializeField] int resourceQuantity = 50;
    [SerializeField] int resourceQuality = 20;

    [SerializeField] Resource[] _resources;
    public Resource[] Resources {get => _resources;}
    [SerializeField] Building[] _buildings;
    public Building[] Buildings {get => _buildings;}
    public Settlement Settlement {get; protected set;}
    


    // Start is called before the first frame update
    void Start()
    {
        Settlement = new Settlement(popPerSettlement, resourceQuantity, resourceQuality);

        //ui_Controller.ShowSettlement(0);
    }


}
