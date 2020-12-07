
using UnityEngine;

public class Shop : MonoBehaviour
{
    buildManager buildManager;

    private void Start()
    {
        buildManager = buildManager.instance;
    }
    public void purchaseM10()
    {
        buildManager.setTurretToBuild(buildManager.m10Prefab);
    }

    public void purchaseCanon()
    {
        buildManager.setTurretToBuild(buildManager.canonPrefab);
    }
   
}
