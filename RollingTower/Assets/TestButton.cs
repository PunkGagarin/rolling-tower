using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class TestButton : ButtonUI {
    

    protected override void ButtonAction() {
        Debug.Log("BUTTON WAS PRESSED");
    }
}