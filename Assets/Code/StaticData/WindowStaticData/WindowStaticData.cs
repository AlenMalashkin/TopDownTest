using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.WindowStaticData
{
    [CreateAssetMenu(fileName = "WindowStaticData", menuName = "Windows", order = 1)]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private List<WindowData> _windows;
        public List<WindowData> Windows => _windows;
    }
}