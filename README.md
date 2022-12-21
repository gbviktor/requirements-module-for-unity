# Requirements Module (WIP)  
this module help you to make any object/entity in your game has some requirements for Lock Object System, Achievements System or somethings else, like Rewards....

---
# Getting Started

## Install with Unity Package Manager
- in Unity go to *Windows > Package Manager*
- press ` + ` and select ` Add package from git URL...`
```cmd
https://github.com/gbviktor/requirements-system-for-unity.git
```

## How to use

>Better way is to use it with my other Packages like Achievements, Stats System etc...
>and It's recommended to use a **Odin Inspector** for better experience

### 1. Create and fill data (Requirements)
In Asset Menu select *Montana Games > DB > Requirements Binder* this create a Scriptable Object, where you can put your for each **key** = **requirements**. 

> In Type **Requirement** field **ID** is a key of Stats in your Game, where value must be Provided by this **key** by IStatsProvider implementation...

### 2. Implement a IStatsProvider intreface


>this interface need to provide values/statistics/data like user XP, money amount and other stats from your Game.
>
>You can also try my **Stats System for Unity** for better experience

#### Example for Steamworks stats provider

```csharp
using Cysharp.Threading.Tasks;
using MontanaGames.Systems.Requirements;

public class SteamStatsProvider : IStatsProvider
{            
	public SteamStatsProvider()
	{
		Steamworks.SteamUserStats.RequestCurrentStats();
	}
	
	int IStatsProvider.ProvideValueFor(string id)
	{
		Steamworks.SteamUserStats.GetStat(id, out int value);
		return value;
	}
}
```

### 3. Use it

After, you can use your Scriptable Object of type *RequermentsBinderSystem* and *IStatsProvider* implementation and get result by **key**, like:

```csharp
public class RequermentsWithSteamExample : MonoBehaviour
{
	[SerializeField] private RequermentsBinderSystem requirements;
	private SteamStatsProvider statsProvider = new SteamStatsProvider();
	
	void Start()
	{
		//get RequirementsComposition by key
		string key = "sometestkey";
		if (requirements.Get(key, out var reqs))
		{
			if (reqs.IsSatisfied(statsProvider))
			{
				//do your staff, requerments are satisfied
				NewAchievemntsGraint(key);
				
			}else {
				//something is not satisfied by requirements
			}
		}
	}
	
	private void NewAchievemntsGraint(string key)
	{
		Debug.Log($"Achievement Graint with key: {key}");
	}
}
```


