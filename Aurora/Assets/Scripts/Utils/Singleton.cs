using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : MonoBehaviour {

	private static T _instance;
	private static object _lock = new object ();

	public static T Instance {
		get { 
			if (applicationIsQuitting) {
				Debug.LogWarning ("[Singleton] Instance '" + typeof(T) + "' aleardy destroyed on application quit." + "Won't create again - returning null.");
				return null;
			}

			lock (_lock) {
				if (_instance == null) {
					_instance = (T) FindObjectOfType (typeof (T));

					if (FindObjectsOfType (typeof (T)).Length > 1) {
						Debug.LogError ("[Singleton] Somethin went wrong - There should never be more than 1 singleton. Repopening the scene might fix it.");
						return _instance;
					}

					if (_instance == null) {
						GameObject singleton = new GameObject ();
						_instance = singleton.AddComponent<T> ();
						singleton.name = "(singleton) " + typeof (T).ToString ();
						DontDestroyOnLoad (singleton);
					}
					else {
						Debug.Log ("[Singleton] An instance of " + typeof (T) + " is already being used");
					}
				}

				return _instance;
			}
		}
	}

	private static bool applicationIsQuitting = false;

	public void OnDestroy () {
		applicationIsQuitting = true;
	}
}