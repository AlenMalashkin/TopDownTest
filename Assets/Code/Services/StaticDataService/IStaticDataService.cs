using Code.Data;
using Code.GameLogic.EnemiesLogic;
using Code.GameLogic.Pickups;
using Code.GameLogic.Weapons;
using Code.StaticData.LevelStaticData;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void LoadStaticData();
        LevelStaticData ForLevel();
        WindowData ForWindow(WindowType type);
        WeaponConfig ForWeapon(WeaponType type);
        EnemyData ForEnemy(EnemyType type);
        PickupBonusData ForPickupBonus(BonusType type);
        PickupWeaponData ForPickupWeapon(WeaponType type);
    }
}