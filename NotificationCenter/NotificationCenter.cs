using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationCenter {
	private static NotificationCenter _instance;
	public static NotificationCenter getInstance() {
		if (_instance == null)
			_instance = new NotificationCenter ();
		return _instance;
	}

	Dictionary<string, List<NotificationDelegate>> _table = new Dictionary<string, List<NotificationDelegate>>();


	public delegate void NotificationDelegate(string eventName, object data);

	public void addEvent(string name, NotificationDelegate delega) {
		if (!_table.ContainsKey (name)) {
			_table.Add (name, new List<NotificationDelegate> ());
		}
		List<NotificationDelegate> list = _table [name]; // for sure
		if (!list.Contains (delega))
			list.Add (delega);
	}

	public void removeEvent(string name, NotificationDelegate delega) {
		if (_table.ContainsKey (name)) {
			List<NotificationDelegate> list = _table [name];
			if (list != null && list.Contains (delega)) {
				_table [name].Remove (delega);
			}
		}
	}

	public void dispatchEvent(string name, object data) {
		if (_table.ContainsKey (name)) {
			List<NotificationDelegate> listOrign = _table [name];
			List<NotificationDelegate> list = new List<NotificationDelegate>(_table [name]);
			foreach (var item in list) {
				if (item != null && listOrign.Contains(item))
					item (name, data);
			}
		}
	}
}
