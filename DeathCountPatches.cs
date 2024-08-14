using Framework.Managers;
using Framework.Map;
using Gameplay.UI.Others.MenuLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace Blasphemous.DeathCounter;

//Creates OnMapUpdate Method
[HarmonyPatch(typeof(NewMapMenuWidget), nameof(NewMapMenuWidget))]
class MapMenuWidetShow_Patch
{
    public static void PostFix()
    {
        Main.DeathCounter.OnMapOpen();
    }
}