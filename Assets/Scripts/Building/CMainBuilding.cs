using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMainBuilding : MonoBehaviour
{
    private int FilledHexagonCount = 0;
    private List<GameObject> EmptyHexagonsList = new List<GameObject>();
    public void GetEmptyHexagonsWithConnectedMainBuildings()
    {
        int count = 0;
        for (int i = 1; i < gameObject.transform.parent.childCount; i++)
        {
            if (gameObject.transform.parent.GetChild(i).GetComponent<CEmptyHexagonChecker>().GetBuildingObj() != null)
            {
                count++;
            }
        }
        FilledHexagonCount = count;
    }
    public int GetFilledHexagonCount()
    {
        return FilledHexagonCount;
    }
    public void AddToEmptyHexagonList(GameObject hexagon)
    {
        EmptyHexagonsList.Add(hexagon);
    }
    public void DestroyBuilding()
    {
        foreach(GameObject obj in EmptyHexagonsList)
        {
            if(obj != null)
            {
                obj.GetComponent<CEmptyHexagonChecker>().CheckIfDeletedBuildingInCurrentHexagon();
            }
            
        }
        Destroy(gameObject.transform.parent.gameObject);
    }
}
