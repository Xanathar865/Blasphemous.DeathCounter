using Framework.Managers;
using Framework.Map;
using Gameplay.UI.Others.MenuLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace Blasphemous.DeathCounter;

//Creates OnMapOpen Method
[HarmonyPatch(typeof(NewMapMenuWidget), nameof(NewMapMenuWidget.OnShow))]
class MapMenuWidetShow_Patch
{
    public static void Postfix()
    {
        Main.DeathCounter.OnMapOpen();
    }
}