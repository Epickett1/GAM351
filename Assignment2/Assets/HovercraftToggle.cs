using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovercraftToggle : MonoBehaviour
{
    public int selectedHovercraft = 0;
    // Start is called before the first frame update
    void Start() {
        SelectHovercraft();
    }

    // Update is called once per frame
    void Update() {
        int previousSelectedHovercraft = selectedHovercraft;
        
        if (Input.GetKeyDown(KeyCode.C)) {
            selectedHovercraft++;
            selectedHovercraft %= transform.childCount;
        }

        if (previousSelectedHovercraft != selectedHovercraft) {
            SelectHovercraft();
        }
        
    }

    public void SelectHovercraft() {
        int i = 0;
        foreach (Transform hovercraft in transform) {
            if (i == selectedHovercraft) {
                hovercraft.gameObject.SetActive(true);
            }
            else {
                hovercraft.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
