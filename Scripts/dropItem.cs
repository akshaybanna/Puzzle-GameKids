using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class dropItem : MonoBehaviour , IDropHandler
{

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (PanelDragBehavior.IBeginDragged.transform.position == gameObject.transform.position) {
			PanelDragBehavior.IBeginDragged.transform.position = gameObject.transform.position;
		}
	}
	#endregion
}
