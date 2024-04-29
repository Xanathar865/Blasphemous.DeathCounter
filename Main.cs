using BepInEx;

namespace Blasphemous.DeathCounter;

[BepInPlugin(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_VERSION)]
[BepInDependency("Blasphemous.ModdingAPI", "0.1.0")]
public class Main : BaseUnityPlugin
{
    public static DeathCounter DeathCounter { get; private set; }

    private void Start()
    {
        DeathCounter = new DeathCounter();
    }
}
