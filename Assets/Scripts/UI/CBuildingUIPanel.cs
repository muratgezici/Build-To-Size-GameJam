using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CBuildingUIPanel : MonoBehaviour
{
    [SerializeField] GameObject CountText;
    [SerializeField] private GameObject MainBuildingActions;
    private GameObject CurrentBuilding;
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    public void SetCountText(string countText, GameObject building)
    {
        CurrentBuilding = building;
        CountText.GetComponent<TextMeshProUGUI>().text = "Bordering Buildings: " + countText;
    }
    public void OnDeleteBuildingButtonClicked()
    {
        MainBuildingActions.GetComponent<CMainBuildingActions>().DisableUI();
        CurrentBuilding.GetComponent<CMainBuilding>().DestroyBuilding();
        CurrentBuilding = null;
    }
}
