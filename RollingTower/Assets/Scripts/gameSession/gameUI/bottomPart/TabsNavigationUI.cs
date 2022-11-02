using System;
using System.Collections.Generic;
using System.Linq;
using gameSession.gameUI.bottomPart;
using UnityEngine;

public class TabsNavigationUI : MonoBehaviour {

    private List<TabButtonUI> _tabs;

    [SerializeField]
    private ContentHolder _contentHolder;

    private void Awake() {
        _tabs = GetComponentsInChildren<TabButtonUI>().ToList();
        foreach (var tab in _tabs) {
            tab.OnTabButtonClicked += ChangeTab;
        }
    }

    private void ChangeTab(InGameTabType tabType) {
        _contentHolder.ChangeContentTabByType(tabType);
    }

    private void OnDestroy() {
        foreach (var tab in _tabs) {
            tab.OnTabButtonClicked -= ChangeTab;
        }
    }
    
    
}