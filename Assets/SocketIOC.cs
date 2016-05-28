using UnityEngine;
using System.Collections;
using SocketIOClient;

public class SocketIOC : MonoBehaviour {
	Client socket;

	void Start () {
		socket = new Client("http://192.168.3.250:9876");
		socket.On("connect", (fn) => {
			Debug.Log ("connect - socket");
			socket.Emit("add user", "user_unity");
		});
		socket.On("user joined", (data) => {
			Debug.Log(data);
		});
		socket.Error += (sender, e) => {
			Debug.Log ("socket Error: " + e.Message.ToString ());
		};
		socket.Connect();
	}
}
