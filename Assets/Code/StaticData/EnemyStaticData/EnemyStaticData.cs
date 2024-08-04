using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.EnemyStaticData
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "Enemy", order = 3)]
    public class EnemyStaticData : ScriptableObject
    {
        [SerializeField] private List<EnemyData> _enemies;
        public List<EnemyData> Enemies => _enemies;
    }
}