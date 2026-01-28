﻿using Blasphemous.ModdingAPI;
using Blasphemous.ModdingAPI.Persistence;
using System;
using Blasphemous.DeathCounter.Events;
using JetBrains.Annotations;
using Blasphemous.CheatConsole;
using Blasphemous.Framework.UI;
using Gameplay.UI.Others.MenuLogic;
using Gameplay.UI.Others.UIGameLogic;
using UnityEngine;
using UnityEngine.UI;
using Framework.Managers;
using Framework.Map;
using System.Linq;
using System.Text;
using Epic.OnlineServices.Lobby;
using Tools.Playmaker2.Action;

namespace Blasphemous.DeathCounter;

public class DeathCount : BlasMod, ISlotPersistentMod<DeathCountData>
{

    internal Events.EventHandler EventHandler { get; } = new();
    public DeathCount() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    public int Deaths { get; set; }

    private Text DeathText;

    public void LoadSlot(DeathCountData data)
    {

        Deaths = data.saveAmount;
    }

    public DeathCountData SaveSlot()
    {
        return new DeathCountData()
        {
            saveAmount = Deaths,
        };
    }

    public void ResetSlot()
    {
        Deaths = 0;
    }

    //Manages the increase in death count
    private void IncreaseCount()
    {
        Deaths++;
        ModLog.Debug($"DeathCounter: Increasing DeathCount to {Deaths}");
    }

    protected override void OnInitialize()
    {
        ModLog.Info($"{ModInfo.MOD_NAME} has been initialized");
        //Calls for IncreaseCount on player death
        Main.DeathCounter.EventHandler.OnPlayerKilled += IncreaseCount;
    }

    //Register deathcounter command
    protected override void OnRegisterServices(ModServiceProvider provider)
    {
        provider.RegisterCommand(new DeathCounterCommand());
    }

    //Display text if it isn't already displayed
    public void OnMapOpen()
    {
        if (DeathText == null)
            CreateText();

        void CreateText()
        {
            Transform parent = UnityEngine.Object.FindObjectOfType<NewMapMenuWidget>()?.transform;
            if (parent == null)
                return;

            DeathText = UIModder.Create(new RectCreationOptions()
            {
                Name = "Death Counter",
                Parent = parent,
                XRange = Vector2.zero,
                YRange = Vector2.one,
                Pivot = new Vector2(0, 1),
                Position = new Vector2(455, -15),
                Size = new Vector2(250, 250)
            }).AddText(new TextCreationOptions()
            {
                Contents = "Deaths = " + Deaths,
                Font = UIModder.Fonts.Blasphemous,
                Color = new Color(248 / 255f, 228 / 255f, 199 / 255f),
                Alignment = TextAnchor.UpperLeft
            });
        }

        DeathText.text = "Deaths = " + Deaths;
    }
}

public class DeathCountData : SlotSaveData
{
    public int saveAmount;
}