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
        if (!IsInfoPanelOpen && Input.GetMouseButtonDown(0))
        {
            CheckMouseHitObjectByTag(Camera.main, "MainBuilding");
            
        }
        else if(IsInfoPanelOpen && Input.GetMouseButtonDown(0))
        {
            BuildingInfoPanel.SetActive(false);
            LastClickedBuilding = null;
            IsInfoPanelOpen = false;
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
                if (LastClickedBuilding != null && LastClickedBuilding != hit.collider.gameObject)
                {
                    LastClickedBuilding = hit.collider.gameObject;
                    BuildingInfoPanel.SetActive(true);
                    BuildingInfoPanel.transform.position = LastClickedBuilding.transform.position + new Vector3(0,5.2f,0);
                    LastClickedBuilding.GetComponent<CMainBuilding>().GetEmptyHexagonsWithConnectedMainBuildings();
                    string counttext = LastClickedBuilding.GetComponent<CMainBuilding>().GetFilledHexagonCount()+"";
                    BuildingInfoPanel.GetComponent<CBuildingUIPanel>().SetCountText(counttext);
                    IsInfoPanelOpen = true;
                }
                else
                {
                    LastClickedBuilding = hit.collider.gameObject;
                    BuildingInfoPanel.SetActive(true);
                    BuildingInfoPanel.transform.position = LastClickedBuilding.transform.position + new Vector3(0, 5.2f, 0);
                    LastClickedBuilding.GetComponent<CMainBuilding>().GetEmptyHexagonsWithConnectedMainBuildings();
                    string counttext = LastClickedBuilding.GetComponent<CMainBuilding>().GetFilledHexagonCount() + "";
                    BuildingInfoPanel.GetComponent<CBuildingUIPanel>().SetCountText(counttext);
                    IsInfoPanelOpen = true;
                }
            }
            else if (LastClickedBuilding != null)
            { 
                LastClickedBuilding = null;
                BuildingInfoPanel.SetActive(false);
                IsInfoPanelOpen = false;
            }

        }
        

        return false;
    }
}
