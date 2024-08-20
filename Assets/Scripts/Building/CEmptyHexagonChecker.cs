using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEmptyHexagonChecker : MonoBehaviour
{
    [SerializeField] private bool IsNewBuildingPlaceable = true;
    private GameObject BuildingObj;
    private List<GameObject> EnemyInsideEmptyList = new List<GameObject>();
    [SerializeField] private Material HalfTransparentMat;
    [SerializeField] private Material FullTransparentMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBuilding"))
        {
            BuildingObj = other.gameObject;
            IsNewBuildingPlaceable = false;
            gameObject.GetComponent<Renderer>().material = FullTransparentMat;
            BuildingObj.GetComponent<CMainBuilding>().AddToEmptyHexagonList(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            
            IsNewBuildingPlaceable = false;
            EnemyInsideEmptyList.Add(other.gameObject);
            gameObject.GetComponent<Renderer>().material = FullTransparentMat;
            Debug.Log(gameObject.name + "enemy entered: " + EnemyInsideEmptyList.Count);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyInsideEmptyList.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        bool is_any_enemy_inside = false;
        foreach(GameObject go in EnemyInsideEmptyList)
        {
            if(go != null)
            {
                is_any_enemy_inside = true;
            }
        }
        if(BuildingObj == null && !is_any_enemy_inside)
        {
            IsNewBuildingPlaceable = true;
        }
        else if (BuildingObj == null && is_any_enemy_inside)
        {
            IsNewBuildingPlaceable = false;
        }
    }
    public void CheckIfDeletedBuildingInCurrentHexagon()
    {
        if (!IsNewBuildingPlaceable)
        {
                IsNewBuildingPlaceable = true;
            
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
