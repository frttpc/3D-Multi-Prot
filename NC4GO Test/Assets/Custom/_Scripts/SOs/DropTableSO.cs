using System;
using System.Collections.Generic;
using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(menuName = "Scriptable Objects /Drop Table")]
    public class DropTableSO : ScriptableObject
    {
        public DropItem[] dropTable;
    }

    [Serializable]
    public struct DropItem
    {
        public Transform powerUpPrefab;
        [ColorUsage(true, true)]
        public Color shineColor;
        public int dropWeight;
    }
}