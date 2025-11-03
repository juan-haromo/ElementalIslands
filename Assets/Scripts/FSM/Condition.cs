using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public abstract bool Check(FSMController controller);
}
