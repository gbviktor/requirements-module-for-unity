using UnityEngine;

namespace MontanaGames.Systems.Requirements
{
    [CreateAssetMenu(fileName = "RequirementsBindSystem", menuName = "Montana Games/DB/Requirements Binder", order = 1)]
    public class RequirementsBinderScriptable : ScriptableObject
    {
        [SerializeField] RequermentsBinderSystem system;
    }
}