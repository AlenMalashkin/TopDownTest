using Code.GameLogic.Zones;
using UnityEngine;

namespace Code.Infrastructure.Factories.ZoneFactory
{
    public interface IZoneFactory
    {
        Zone CreateSlowZone(Vector3 position);
        Zone CreateDeathZone(Vector3 position);
    }
}