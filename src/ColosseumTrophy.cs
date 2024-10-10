using System.Reflection;
using JetBrains.Annotations;
using Modding;
using SFCore.Utils;
using UnityEngine.SceneManagement;

namespace ColosseumTrophy;

[UsedImplicitly]
internal class ColosseumTrophy : Mod
{
    internal static ColosseumTrophy Instance;

    public ColosseumTrophy() : base("Colosseum Gold Trophy")
    {
        InitCallbacks();
    }

    public override string GetVersion() => Util.GetVersion(Assembly.GetExecutingAssembly());

    public override void Initialize()
    {
        Log("Initializing");
        Instance = this;

        Log("Initialized");
    }

    private void InitCallbacks()
    {
        // Hooks
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene from, Scene to)
    {
        if (to.name != "Room_Colosseum_Bronze" && to.name != "Room_Colosseum_Silver" && to.name != "Room_Colosseum_Gold")
        {
            return;
        }
        to.Find("colosseum gold trophy").SetActive(true);
    }
}