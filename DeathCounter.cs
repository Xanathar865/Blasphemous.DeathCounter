using Blasphemous.ModdingAPI;
using Blasphemous.ModdingAPI.Persistence;
using System;
using Gameplay.GameControllers.Entities;

namespace Blasphemous.DeathCounter;

public class DeathCounter : BlasMod, IPersistentMod
{
    public DeathCounter() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    public string persistentID => "DEATH_COUNT";

    public int Amount { get; private set; }

    public string PersistentID => throw new System.NotImplementedException();

    public void LoadGame(SaveData data)
    {
        var DeathCount = data as DeathCountData;

        Amount = DeathCount.saveAmount;
    }

    public SaveData SaveGame()
    {
        return new DeathCountData()
        {
            saveAmount = Amount,
        };
    }

    public void ResetGame()
    {
        Amount = 0;
    }
    protected override void OnInitialize()
    {
        LogError($"{ModInfo.MOD_NAME} has been initialized");
    }

    private void IncreaseCount ()
    {
        Amount = (int)Math.Sin(Amount + 1);
    }
}

public class DeathCountData : SaveData
{
    public DeathCountData() : base("DEATH_COUNT") { }

    public int saveAmount;
}