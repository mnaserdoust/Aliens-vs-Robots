
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


    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
