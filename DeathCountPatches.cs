using Framework.Managers;
using Framework.Map;
using Gameplay.UI.Others.MenuLogic;
using HarmonyLib;
using System.Collections.Generic;

namespace Blasphemous.DeathCounter;

//Creates OnMapUpdate Method
[HarmonyPatch(typeof(NewMapMenuWidget), "MapEnabled" )]
class MapMenuWidetShow_Patch
{
    public static void Postfix()
    {
        Main.DeathCounter.OnMapOpen();
    }
}