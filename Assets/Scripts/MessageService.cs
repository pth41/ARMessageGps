namespace Mapbox.Unity.Ar
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using LitJson;

	public class MessageService : MonoBehaviour {

		/// <summary>
		/// 이 클래스는 새 메시지를 삭제, 로드 및 작성하기 위해
		/// 서버와의 통신을 처리합니다.
		/// 새 메시지 개체가 여기에 인스턴스화됩니다.
		/// </summary>
		private static MessageService _instance;
		public static MessageService Instance { get { return _instance; } } 

		public Transform mapRootTransform;

		public GameObject messagePrefabAR;

		void Awake(){
			_instance = this;
		}

		public void RemoveMessages(){
		}

		public void LoadMessages() {
			
			List<GameObject> messageObjectList = new List<GameObject> ();

			for(int i = 0; i < TestServer.Instance.text.Count; i++) {
				// 메시지ar오브젝트 인스턴스화 및 데이터 로드
				GameObject MessageBubble = Instantiate (messagePrefabAR,mapRootTransform);
				Message message = MessageBubble.GetComponent<Message>();

				message.latitude = TestServer.Instance.latitude[i];
				message.longitude = TestServer.Instance.longitude[i];
				message.text = TestServer.Instance.text[i];
				messageObjectList.Add(MessageBubble);
			}
			// 객체 목록을 배치할 수 있도록 MessageProvider 에게 전달
			MessageProvider.Instance.LoadARMessages (messageObjectList);

		}
			
		public void SaveMessage(double lat, double lon, string text){
			TestServer.Instance.latitude.Add (lat);
			TestServer.Instance.longitude.Add (lon);
			TestServer.Instance.text.Add (text);

		}
			
	}
}
