
using UnityEngine;

public class buildManager : MonoBehaviour
{
    public static buildManager instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject m10Prefab;
    public GameObject canonPrefab;


    private GunBluePrint turretToBuild;

    public bool canbuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return playerStats.Money >= turretToBuild.cost; } }

    public void selectTurretToBuild(GunBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void buildGunOn(Node node)
    {
        if (playerStats.Money < turretToBuild.cost) return;

        playerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
