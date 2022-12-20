using System;

using UnityEngine;
using UnityEngine.Rendering;

namespace MontanaGames.Systems.Requirements
{
    [Serializable]
    public sealed class RequermentsBinderSystem
    {
        [SerializeField]
        SerializedDictionary<string, RequirementsComposition> requerments;
        public RequermentsBinderSystem(SerializedDictionary<string, RequirementsComposition> requerments)
        {
            this.requerments = requerments;
        }

        public RequermentsBinderSystem()
        {
            this.requerments = new SerializedDictionary<string, RequirementsComposition>();
        }

        public bool Get(string id, out RequirementsComposition reqs)
        {
            return requerments.TryGetValue(id, out reqs);
        }

        public void Bind(string id, RequirementsComposition reqs)
        {
            requerments[id] = reqs;
        }
    }
}