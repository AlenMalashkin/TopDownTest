using System;
using UnityEngine;

namespace Code.GameLogic.EnemiesLogic
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        public event Action Died;
        
        private float _maxHealth;
        private float _currentHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;

        public void Init(float health)
        {
            _maxHealth = health;
            _currentHealth = health;
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0)
                Died?.Invoke();
        }
    }
}