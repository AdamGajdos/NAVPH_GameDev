using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implemented for menus which have the selection possibility(for example choosing hero character or choosing specific saved game)
public class ChoiceMenu : MonoBehaviour
{
    public virtual void HandleSelected(string choice) { }
}
