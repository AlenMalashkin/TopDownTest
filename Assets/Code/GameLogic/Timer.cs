using System;
using UnityEngine;

namespace Code.GameLogic
{
    public class Timer
    {
        private float _secondsRemain;
        private Action _finishAction;

        public void StartTimer(float seconds, Action finishAction = null)
        {
            _secondsRemain = seconds;
            _finishAction = finishAction;
        }

        public void Tick()
        {
            if (_secondsRemain > 0)
            {
                _secondsRemain -= Time.deltaTime;

                if (_secondsRemain <= 0)
                    _finishAction?.Invoke();
            }
        }

        public void Reset()
        {
            _secondsRemain = 0;
            _finishAction = null;
        }
    }
}