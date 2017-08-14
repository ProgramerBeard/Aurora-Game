using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseActionDatabase : MonoBehaviour {

	public ActionDatabase database;

	Action action;

	private void Awake () {
		if (!database) {
			database = Resources.Load ("ActionDatabase") as ActionDatabase;
		}
	}

	public Action Find (int id) {
		foreach (Action a in database.actions) {
			if (a.idNumber == id) {
				return a;
			}
		}

		return null;
	}
}