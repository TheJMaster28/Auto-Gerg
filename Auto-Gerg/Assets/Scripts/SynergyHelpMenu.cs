using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SynergyHelpMenu : MonoBehaviour, IPointerClickHandler {

    public GameObject toolTip;
    bool isSet = false;
    public void OnPointerClick (PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log ("right click");
            isSet = !isSet;
            toolTip.SetActive (isSet);
        }
    }
}