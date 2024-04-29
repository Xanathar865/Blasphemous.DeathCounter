using Blasphemous.DeathCounter;
using Gameplay.GameControllers.Enemies.Framework.Damage;
using Gameplay.GameControllers.Entities;
using Gameplay.GameControllers.Penitent.Damage;
using HarmonyLib;
using Tools.Level.Interactables;

namespace Blasphemous.DeathCounter.Events;

[HarmonyPatch(typeof(Entity), "KillInstanteneously")]
class Penitent_Death_Patch
{
    public static void Postfix(Entity __instance) => Main.DeathCounter.EventHandler.KillEntity(__instance);
}

[HarmonyPatch(typeof(PrieDieu), "OnUse")]
class PrieDieu_Use_Patch
{
    public static void Prefix() => Main.DeathCounter.EventHandler.UsePrieDieu();
}

[HarmonyPatch(typeof(PenitentDamageArea), "RaiseDamageEvent")]
class Penitent_Damage_Patch
{
    public static void Prefix(ref Hit hit) => Main.DeathCounter.EventHandler.DamagePlayer(ref hit);
}

[HarmonyPatch(typeof(EnemyDamageArea), "TakeDamageAmount")]
class Enemy_Damage_Patch
{
    public static void Prefix(ref Hit hit) => Main.DeathCounter.EventHandler.DamageEnemy(ref hit);
}