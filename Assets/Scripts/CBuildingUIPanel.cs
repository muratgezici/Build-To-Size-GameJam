using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CBuildingUIPanel : MonoBehaviour
{
    [SerializeField] GameObject CountText;

    public void SetCountText(string countText)
    {
        CountText.GetComponent<TextMeshProUGUI>().text = "Bordering Buildings: " + countText;
    }
}
