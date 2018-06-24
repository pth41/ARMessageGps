namespace Mapbox.Unity.Ar
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIBehaviorT : MonoBehaviour {
		/// <summary>
		/// 이 클래스에는 UI에서 버튼을 누르면 호출되는 기능들이 있습니다.
		/// </summary>
		private static UIBehaviorT _instance;
		public static UIBehaviorT Instance { get { return _instance; } } 

		public GameObject HomeScreen;
		public GameObject MessageScreen;
		public Text messageText;

		void Awake(){
			_instance = this;
			HomeScreen.SetActive (false);
			MessageScreen.SetActive (false);
		}

		public void ShowHomeUI(){
			HomeScreen.SetActive (true);
		}

		public void RemoveButtonDown(){
			HomeScreen.SetActive (false);
			MessageServiceT.Instance.RemoveMessages ();
			MessageProviderT.Instance.RemoveCurrentMessages ();
			StartCoroutine (DelayRemoveRoutine ());
		}

		IEnumerator DelayRemoveRoutine(){
			yield return new WaitForSeconds (2f);
			HomeScreen.SetActive (true);
		}

		public void ShowMessageUI(){
			HomeScreen.SetActive (false);
			MessageScreen.SetActive (true);
		}

		public void BlockButtonDown(){
			//차단기능 보류
		}

		public void SubmitButtonDown(){
			double lat = MessageProviderT.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.x;
			double lon = MessageProviderT.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.y;

			MessageServiceT.Instance.SaveMessage (lat, lon, messageText.text);

			messageText.text = "";
			HomeScreen.SetActive (true);
			MessageScreen.SetActive (false);
			StartCoroutine (DelayLoadMessagesRoutine ());
		}

		IEnumerator DelayLoadMessagesRoutine(){
			yield return new WaitForSeconds (1f);
			MessageServiceT.Instance.LoadMessages ();
		}
	}
}
