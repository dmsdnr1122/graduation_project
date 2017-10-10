using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots;
	//[SerializeField] Text inventoryText;
	// Use this for initialization
	public Image bluekey;
	public Image graykey;
	public Image greenkey;


    
	void Start () {
		HasChanged ();
	}
	#region IHasChanged implementation
	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
		builder.Append (" - ");
		foreach (Transform slotTransform in slots) {
			
			GameObject item = slotTransform.GetComponent<SlotHandler> ().item;
			if (item) {
				builder.Append (item.name);
				builder.Append (" - ");
			}
		}

		//inventoryText.text = builder.ToString ();
	}
    #endregion
}

namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged ();
	}
}
