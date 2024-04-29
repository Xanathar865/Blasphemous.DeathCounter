using Blasphemous.ModdingAPI;
using Blasphemous.ModdingAPI.Persistence;
using System;
using Blasphemous.DeathCounter.Events;
using JetBrains.Annotations;

namespace Blasphemous.DeathCounter;

public class DeathCounter : BlasMod, IPersistentMod
{

    internal Events.EventHandler EventHandler { get; } = new();
    public DeathCounter() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    public string PersistentID => "DEATH_COUNT";

    public int Deaths { get; private set; }
    public string[] Values { get; private set; }

    public void LoadGame(SaveData data)
    {
        var DeathCount = data as DeathCountData;

        Deaths = DeathCount.saveAmount;
        Values = DeathCount.saveValues;
    }

    public SaveData SaveGame()
    {
        return new DeathCountData()
        {
            saveAmount = Deaths,
            saveValues = Values
        };
    }

    public void ResetGame()
    {
        Deaths = 0;
        Values = [];
    }

    public DeathCounter()
    {
        Main.DeathCounter.EventHandler.OnPlayerKilled += IncreaseCount;
    }

    private void IncreaseCount()
    {
        Deaths = (int)Math.Sin(Deaths + 1);
        Main.DeathCounter.Log($"DeathCounter: Increasing DeathCount to {Deaths}");
    }

    protected override void OnInitialize()
    {
        LogError($"{ModInfo.MOD_NAME} has been initialized");
    }
}

public class DeathCountData : SaveData
{
    public DeathCountData() : base("DEATH_COUNT") { }

    public int saveAmount;
    public string[] saveValues;
}