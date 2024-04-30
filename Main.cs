using BepInEx;

namespace Blasphemous.DeathCounter;

[BepInPlugin(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_VERSION)]
[BepInDependency("Blasphemous.ModdingAPI", "2.1.2")]
[BepInDependency("Blasphemous.CheatConsole", "1.0.0")]
[BepInDependency("Blasphemous.Framework.UI", "0.1.0")]
public class Main : BaseUnityPlugin
{
    public static DeathCounter DeathCounter { get; private set; }

    private void Start()
    {
        DeathCounter = new DeathCounter();
    }
}
