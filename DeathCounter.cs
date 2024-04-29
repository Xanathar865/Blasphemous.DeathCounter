﻿using Blasphemous.ModdingAPI;
using Blasphemous.ModdingAPI.Persistence;
using System;
using Blasphemous.DeathCounter.Events;
using JetBrains.Annotations;
using Blasphemous.CheatConsole;

namespace Blasphemous.DeathCounter;

public class DeathCounter : BlasMod, IPersistentMod
{

    internal Events.EventHandler EventHandler { get; } = new();
    public DeathCounter() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    public string PersistentID => "DEATH_COUNT";

    public int Deaths { get; set; }

    public void LoadGame(SaveData data)
    {
        var DeathCount = data as DeathCountData;

        Deaths = DeathCount.saveAmount;
    }

    public SaveData SaveGame()
    {
        return new DeathCountData()
        {
            saveAmount = Deaths,
        };
    }

    public void ResetGame()
    {
        Deaths = 0;
    }

    //Manages the increase in death count
    private void IncreaseCount()
    {
        Deaths++;
        Main.DeathCounter.Log($"DeathCounter: Increasing DeathCount to {Deaths}");
    }

    protected override void OnInitialize()
    {
        LogError($"{ModInfo.MOD_NAME} has been initialized");
        //Calls for IncreaseCount on player death
        Main.DeathCounter.EventHandler.OnPlayerKilled += IncreaseCount;
    }

    //Register deathcounter command
    protected override void OnRegisterServices(ModServiceProvider provider)
    {
        provider.RegisterCommand(new DeathCounterCommand());
    }
}

public class DeathCountData : SaveData
{
    public DeathCountData() : base("DEATH_COUNT") { }

    public int saveAmount;
}