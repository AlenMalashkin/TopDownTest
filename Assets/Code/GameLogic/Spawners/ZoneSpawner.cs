using System.Collections.Generic;
using Code.Infrastructure.Factories.ZoneFactory;
using Code.StaticData.LevelStaticData;
using UnityEngine;

namespace Code.GameLogic.Spawners
{
    public class ZoneSpawner : Spawner
    {
        private List<Vector3> _zonePositions = new List<Vector3>();
        private float _distanceBetweenZones = 3f;
        
        private IZoneFactory _zoneFactory;

        public ZoneSpawner(LevelStaticData levelStaticData, IZoneFactory zoneFactory) : base(levelStaticData)
        {
            _zoneFactory = zoneFactory;
        }
        
        public void SpawnZones()
        {
            for(int i = 0; i < 3; i++)
            {
                Vector3 position = FindNextPosition();
                _zonePositions.Add(_zoneFactory.CreateSlowZone(position + Vector3.up).transform.position);
            }
            for (int i = 0; i < 2; i++)
            {
                Vector3 position = FindNextPosition();
                _zonePositions.Add(_zoneFactory.CreateDeathZone(position + Vector3.up).transform.position);
            }
        }

        private Vector3 FindNextPosition()
        {
            Vector3 position = Vector3.zero;
            bool isPositionValid = false;

            while (!isPositionValid)
            {
                position = GetRandomPosition();
                isPositionValid = true;

                foreach (var zone in _zonePositions)
                {
                    if (Vector3.Distance(position, zone) < _distanceBetweenZones)
                    {
                        isPositionValid = false;
                        break;
                    }
                }
            }

            return position;
        }
    }
}