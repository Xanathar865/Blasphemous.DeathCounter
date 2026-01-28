using BepInEx;

namespace Blasphemous.DeathCounter;

[BepInPlugin(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_VERSION)]
[BepInDependency("Blasphemous.ModdingAPI", "3.0.0")]
[BepInDependency("Blasphemous.CheatConsole", "1.0.1")]
[BepInDependency("Blasphemous.Framework.UI", "0.1.2")]
public class Main : BaseUnityPlugin
{
    public static DeathCount DeathCounter { get; private set; }

    private void Start()
    {
        DeathCounter = new DeathCount();
    }
}
