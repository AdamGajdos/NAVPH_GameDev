using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionButtonController : ButtonManager
{
    public override void ProceedChoice()
    {
        string choice = gameObject.GetComponentInChildren<TMP_Text>()?.text;

        if (choice != null)
        {
            manager.HandleSelected(choice);
        }
    }
}
