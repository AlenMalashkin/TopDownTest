using Code.GameLogic.Zones;
using UnityEngine;

namespace Code.Infrastructure.Factories.ZoneFactory
{
    public class ZoneFactory : IZoneFactory
    {
        public Zone CreateSlowZone(Vector3 position)
        {
            Zone prefab = Resources.Load<Zone>("Prefabs/Zones/SlowZone");
            Zone zone = Object.Instantiate(prefab, position, Quaternion.identity);
            return zone;
        }

        public Zone CreateDeathZone(Vector3 position)
        {
            Zone prefab = Resources.Load<Zone>("Prefabs/Zones/DeathZone");
            Zone zone = Object.Instantiate(prefab, position, Quaternion.identity);
            return zone;
        }
    }
}