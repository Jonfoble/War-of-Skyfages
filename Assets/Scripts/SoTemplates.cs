using UnityEngine;

[CreateAssetMenu(fileName = "New Template", menuName = "Template", order = 0)]
public class SoTemplates : ScriptableObject
{
    public SoValues lightUnitValues;
    public SoValues mediumUnitValues;
    public SoValues heavyUnitValues;
    public SoValues specialUnitValues;
}