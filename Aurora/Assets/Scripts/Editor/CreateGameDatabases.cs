using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateGameDatabases {

	[MenuItem ("Assets/Create/Action Database")]
	public static void CreateActionDatabase () {
		ActionDatabase db = ScriptableObject.CreateInstance <ActionDatabase> ();
		AssetDatabase.CreateAsset (db, "Assets/Resources/ActionDatabase.asset");
		AssetDatabase.SaveAssets ();
	}
}
