using System;
using System.Collections.Generic;

using MontanaGames.Systems.Requerments;

using UnityEngine;

namespace MontanaGames.Systems.Requirements
{
    public static class RequirementsCheckerExt
    {
        public static bool IsSatisfied(this IEnumerable<Requirement> requerments, IStatsProvider statsProvider)
        {
            foreach (var requirement in requerments)
            {
                if (!IsActivated(requirement, statsProvider.ProvideValueFor(requirement.id)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CalculateProgressStatusIsFinished(this RequirementsComposition reqs, IStatsProvider stats, out float totalProgress)
        {
            totalProgress = 0;
            bool isComplete = true;

            float maxProgressPerRequirementStep = reqs.Count > 0 ? 100f / (float)reqs.Count : 100f;

            foreach (var req in reqs)
            {
                if (req.IsSatisfied(stats, out int current))
                {
                    totalProgress += maxProgressPerRequirementStep;
                    continue;
                }

                isComplete = false;
                totalProgress += Mathf.Clamp((float)current / (float)req.value * 100, 0, maxProgressPerRequirementStep);
            }

            return isComplete;
        }
        public static bool IsSatisfied(this Requirement req, IStatsProvider statsProvider, out int current)
        {
            current = statsProvider.ProvideValueFor(req.id);
            return IsActivated(req, current); ;
        }
        /// <summary>
        /// Give you feedback about Requirement status, activated or not
        /// </summary>
        /// <param name="req"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static bool IsActivated(in Requirement req, int value)
        {
            Debug.Log($"{req.id} => {value} > {req.value} ");
            return req.Activation switch
            {
                Activation.IS_GREATER_THAT => (value > req.value),
                Activation.IS_LESS_THAT => (value < req.value),
                Activation.IS_EQUALS_TO => (value == req.value),
                Activation.NOT_EQUALS_TO => (value != req.value),
                _ => throw new NotImplementedException(),
            };
        }
    }
}