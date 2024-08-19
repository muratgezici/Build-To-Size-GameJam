using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEmptyHexagonChecker : MonoBehaviour
{
    private bool IsNewBuildingPlaceable = true;
    private GameObject BuildingObj;
    [SerializeField] private Material HalfTransparentMat;
    [SerializeField] private Material FullTransparentMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBuilding"))
        {
            BuildingObj = other.gameObject;
            IsNewBuildingPlaceable = false;
            gameObject.GetComponent<Renderer>().material = FullTransparentMat;
        }
    }
    private void CheckIfDeletedBuildingInCurrentHexagon()
    {
        if (IsNewBuildingPlaceable)
        {
            if (BuildingObj == null)
            {
                BuildingObj = null;
                IsNewBuildingPlaceable = false;
            }
        }
    }
    public void OnBuildModeMouseHover()
    {
        if(IsNewBuildingPlaceable)
        {
            gameObject.GetComponent<Renderer>().material = HalfTransparentMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = FullTransparentMat;
        }
    }
    public void OnBuildModeMouseUnHover()
    {
        gameObject.GetComponent<Renderer>().material = FullTransparentMat;
    }

    public bool GetIsNewBuildingPlaceable()
    {
        return IsNewBuildingPlaceable;
    }
    public GameObject GetBuildingObj()
    {
        return BuildingObj;
    }
}
