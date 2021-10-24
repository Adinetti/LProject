using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LProject.Dictionaries;
using UnityEditor;

namespace LProject {
	[CreateAssetMenu(fileName = "localizations", menuName = "Localization/Create localization")]
	public class Localization : ScriptableObject {
		public Dictionary[] dictionaries;
    }
}


