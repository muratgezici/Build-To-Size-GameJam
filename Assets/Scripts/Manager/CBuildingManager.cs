using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBuildingManager : MonoBehaviour
{
    private GameObject LastHoveredBuilding;
    [SerializeField] GameObject ArcherBuildingPrefab;
    [SerializeField] private GameObject MainBuildingActions;
    private bool ClickedDirectlyAfterInfoPanel = false;

    // Update is called once per frame
    void Update()
    {
        if (!MainBuildingActions.GetComponent<CMainBuildingActions>().GetIsInfoPanelOpen())
        {
            CheckMouseHitObjectByTag(Camera.main, "Empty");
        }
          if (Input.GetMouseButtonDown(0))
          {
            if (!MainBuildingActions.GetComponent<CMainBuildingActions>().GetIsInfoPanelOpen())
            {
                if (!ClickedDirectlyAfterInfoPanel)
                {
                    BuildBuilding();
                }
                ClickedDirectlyAfterInfoPanel = false;
            }
            else
            {
                ClickedDirectlyAfterInfoPanel = true;
            }
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
                if(LastHoveredBuilding != null && LastHoveredBuilding != hit.collider.gameObject)
                {
                    LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().OnBuildModeMouseUnHover();
                    LastHoveredBuilding = hit.collider.gameObject;
                    LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().OnBuildModeMouseHover();
                }
                else
                {
                    LastHoveredBuilding = hit.collider.gameObject;
                    LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().OnBuildModeMouseHover();
                }
                
            }
            else if (LastHoveredBuilding != null)
            {
                LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().OnBuildModeMouseUnHover();
                LastHoveredBuilding = null;
            }

        }
        else if(LastHoveredBuilding != null)
        {
            LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().OnBuildModeMouseUnHover();
            LastHoveredBuilding = null;
        }
        return false;
    }
    public void BuildBuilding()
    {
        if (LastHoveredBuilding != null)
        {
            bool is_buildable = LastHoveredBuilding.GetComponent<CEmptyHexagonChecker>().GetIsNewBuildingPlaceable();
            if (is_buildable)
            {
                GameObject obj = Instantiate(ArcherBuildingPrefab, LastHoveredBuilding.transform.position, Quaternion.identity);
            }

        }
    }
}
