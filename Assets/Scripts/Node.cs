
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercoler;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startcolor;

    

    public GameObject turret;


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
        if (!buildManager.canbuild) return;
        if (turret != null)
        {
            Debug.Log("");
        }

        buildManager.buildGunOn(this);
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.canbuild) return;

        if(buildManager.hasMoney)
        {
            rend.material.color = hovercoler;
        }
        else { rend.material.color = notEnoughMoneyColor; }
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
