
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GunBluePrint m10Gun;
    public GunBluePrint canonGun;


    buildManager buildManager;

    private void Start()
    {
        buildManager = buildManager.instance;
    }
    public void purchaseM10()
    {
        buildManager.selectTurretToBuild(m10Gun);
    }

    public void purchaseCanon()
    {
        buildManager.selectTurretToBuild(canonGun);
    }
   
}
