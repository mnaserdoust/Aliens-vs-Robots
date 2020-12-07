
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercoler;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startcolor;

    

    private GameObject turret;


    buildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;

        buildManager = buildManager.instance;
    }


    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (buildManager.getTurretToBuild() == null) return;
        if (turret != null)
        {
            Debug.Log("");
        }

        GameObject turretToBuild = buildManager.getTurretToBuild();

        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation) ;
    }



}
