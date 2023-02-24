using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class DeathTriggeredPanel : MonoBehaviour
{
    [SerializeField] Health Heathnow;
    [SerializeField] PanelOpener PanelOpener;
    private void Update()
    {
        if (Heathnow.currentHealth == 0)
        {
            PanelOpener.JustopenPanel();
        }
    }

}
