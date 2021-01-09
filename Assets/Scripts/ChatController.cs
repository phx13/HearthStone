using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class ChatController : MonoBehaviour {
    public string ipaddress = "127.0.0.1";
    public int port = 7788;
    //public UIInput textInput;
    //public UILabel chatLabel;
    public UITextList textlist;

    private Socket clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];//数据容器
    private string message = "";//消息容器
                                // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        ConnectToServer();
    }

    // Update is called once per frame
    void Update()
    {
        string datetime = DateTime.Now.ToString();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.OnSendButtonClick();
        }
        if (message != null && message != "")
        {
            textlist.Add("\n" + datetime + " " + message);
            //chatLabel.text += "\n" + message + " " + datetime;
            message = "";//清空消息
        }
    }

    void ConnectToServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //跟服务器端建立连接
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipaddress), port));

        //创建一个新的线程 用来接收消息
        t = new Thread(ReceiveMessage);
        t.Start();
    }

    void ReceiveMessage()
    {
        while (true)
        {
            if (clientSocket.Connected == false)
                break;

            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
        }
    }

    //void SendMessage(string message)
    //{
    //    byte[] data = Encoding.UTF8.GetBytes("郭策：" + message);
    //    clientSocket.Send(data);
    //}

    public void OnSendButtonClick()
    {
        GameObject inputLabel = GameObject.Find("inputLabel");
        //string value = textInput.value;
        //SendMessage(value);
        //textInput.value = "";
        string value ="\n" + inputLabel.GetComponent<UILabel>().text;
        GameObject chatInputField = GameObject.Find("chatInputField");
        chatInputField.GetComponent<UIInput>().value = "";
        //textlist.Add(value);
        byte[] data = Encoding.UTF8.GetBytes(value);
        clientSocket.Send(data);
    }

    void OnDestroy()
    {
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();//关闭连接
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
