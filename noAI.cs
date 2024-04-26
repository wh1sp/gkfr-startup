using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using BepInEx;
using HarmonyLib;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace RemoveAI;

[HarmonyPatch(typeof(GameMode), "CreatePlayer")]
public class RAI
{
	public static bool Prefix(ECharacter _Character, ECharacter _Kart, string customName, string hatName, int nbStars, int driverId, int localHumanId, bool lockk, bool isAI, E_AILevel aiLevel)
	{
		return !isAI;
	}
}
[BepInPlugin("com.appkas.gkfr.miscmods", "kaskemod", "1.0.0.0")]
public class Plugin : BaseUnityPlugin
{
	private Harmony h;

	public static bool run;

	private void Awake()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		h = new Harmony("com.appkas.gkfr.miscmods");
		h.PatchAll(Assembly.GetExecutingAssembly());
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
		h.UnpatchSelf();
	}

	static Plugin()
	{
		run = true;
	}
}
