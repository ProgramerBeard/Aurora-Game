using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MehtodExtensionForMonoBehaviourTransform {
	static public T GetOrAddComponent <T> (this Component child) where T : Component {
		T result = child.GetComponent<T> ();

		if (result == null) {
			result = child.gameObject.AddComponent <T> ();
		}

		return result;
	}
}