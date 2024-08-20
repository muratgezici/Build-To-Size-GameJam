using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMainBuildingActions : MonoBehaviour
{
    [SerializeField] private GameObject BuildingInfoPanel;
    private GameObject LastClickedBuilding;
    private bool IsInfoPanelOpen = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseHitObjectByTag(Camera.main, "MainBuilding");
            
        }
       
        
        
    }
    public bool CheckMouseHitObjectByTag(Camera cam, string tag)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (tag == hit.collider.tag)
            {
                
                    LastClickedBuilding = hit.collider.gameObject;
                    ClickedOnBuilding();
                
            }
            else if ("UI" != hit.collider.tag && LastClickedBuilding != null)
            {
                DisableUI();
            }

        }
        

        return false;
    }

    private void ClickedOnBuilding()
    {
        
        BuildingInfoPanel.SetActive(true);
        BuildingInfoPanel.transform.position = LastClickedBuilding.transform.position + new Vector3(0, 7.2f, 0);
        LastClickedBuilding.GetComponent<CMainBuilding>().GetEmptyHexagonsWithConnectedMainBuildings();
        string counttext = LastClickedBuilding.GetComponent<CMainBuilding>().GetFilledHexagonCount() + "";
        BuildingInfoPanel.GetComponent<CBuildingUIPanel>().SetCountText(counttext, LastClickedBuilding);
        IsInfoPanelOpen = true;
    }
    public bool GetIsInfoPanelOpen()
    {
        return IsInfoPanelOpen;
    }
    public void DisableUI()
    {
        LastClickedBuilding = null;
        BuildingInfoPanel.SetActive(false);
        IsInfoPanelOpen = false;
    }
}
