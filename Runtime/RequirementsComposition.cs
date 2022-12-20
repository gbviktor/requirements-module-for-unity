using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace MontanaGames.Systems.Requirements
{
    [Serializable]
    public class RequirementsComposition : IEnumerable<Requirement>
    {
        [SerializeField]
        List<Requirement> Requirements = new List<Requirement>();

        public int Count => Requirements.Count;

        public void Add(in Requirement req)
        {
            Requirements.Add(req);
        }
        public IEnumerator<Requirement> GetEnumerator()
        {
            return Requirements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}