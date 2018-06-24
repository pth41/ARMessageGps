using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMap : MonoBehaviour {
	/// <summary>
	/// 맵박스에 의해 카메라에 오버레이되는 맵을 숨깁니다.
	/// </summary>

	void Start () {
		HideMapCoroutine = StartCoroutine (HideMapRoutine ());
	}

	Coroutine HideMapCoroutine;
	IEnumerator HideMapRoutine(){
		while (true) {
			yield return new WaitForEndOfFrame ();
			if (transform.childCount > 5) {
				DisableChildren ();
			}
		}
	}

	void DisableChildren(){
		StopCoroutine(HideMapCoroutine);
		foreach (Transform child in this.transform) {
			if (child.GetComponent<MeshRenderer>() != null || child.GetComponent<LineRenderer>() != null) {
				child.gameObject.SetActive (false);
			}
		}
	}
}
