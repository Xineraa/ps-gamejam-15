using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LightEffects;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ComboScriptableObject", order = 1)]

public class ComboScriptableObject : ScriptableObject
{
    public Effect effect1;
    public Effect effect2;
}
