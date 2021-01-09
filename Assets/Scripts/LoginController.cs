using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class LoginController : MonoBehaviour {
    public TweenAlpha startLogoTweenAlpha;
    public GameObject messageBox;

    private string loginPassword;

    public MySqlConnection Getmysqlcon()
    {
         string M_str_sqlcon = "server=localhost;user id=root;password=phx25891863;database=hearthstonedb"; //根据自己的设置
         MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
         return myCon;
    }

    public void Getmysqlcom(string M_str_sqlstr)
    { 
         MySqlConnection mysqlcon = this.Getmysqlcon();
         mysqlcon.Open();
         MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
         mysqlcom.ExecuteNonQuery();
         mysqlcom.Dispose();
         mysqlcon.Close();
         mysqlcon.Dispose();
    }

    public MySqlDataReader Getmysqlread(string M_str_sqlstr)
    {
        MySqlConnection mysqlcon = this.Getmysqlcon();
        mysqlcon.Open();
        MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);        
        MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
        mysqlread.Read();
        return mysqlread;
    }

    public void OnApplyButtonClick()
    {
        GameObject loginNameLabel = GameObject.Find("loginNameLabel");
        string name = loginNameLabel.GetComponent<UILabel>().text;
        GameObject loginPasswordLabel = GameObject.Find("loginPasswordLabel");
        string password = loginPasswordLabel.GetComponent<UILabel>().text;
        if ((string)(Getmysqlread("select 密码 from login where 账户名='"+name+"'").GetValue(0))==password)
        {
            startLogoTweenAlpha.PlayForward();
            this.gameObject.SetActive(false);
        }
        else
        {
            messageBox.SetActive(true);
            messageBox.transform.Find("messageBoxLabel").GetComponent<UILabel>().text = "用户名或密码错误，请重新输入";
            StartCoroutine(MessageBoxClose());
        }
    }

    public void OnRegisterButtonClick()
    {
        GameObject loginNameLabel = GameObject.Find("loginNameLabel");
        string name = loginNameLabel.GetComponent<UILabel>().text;
        GameObject loginPasswordLabel = GameObject.Find("loginPasswordLabel");
        string password = loginPasswordLabel.GetComponent<UILabel>().text;

        MySqlConnection mysqlcon = this.Getmysqlcon();
        mysqlcon.Open();
        MySqlCommand mysqlcom = new MySqlCommand("select * from login where 账户名='" + name + "'", mysqlcon);
        MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
        if (mysqlread.Read())
        {
            messageBox.SetActive(true);
            messageBox.transform.Find("messageBoxLabel").GetComponent<UILabel>().text = "该用户名已注册，请重新输入";
            StartCoroutine(MessageBoxClose());
        }
        else
        {
            string sql = "insert into login(账户名,密码)values('" + name + "','" + password + "')";
            Getmysqlcom(sql);
            messageBox.SetActive(true);
            StartCoroutine(MessageBoxClose());
        }
    }

    private IEnumerator MessageBoxClose()
    {
        yield return new WaitForSeconds(3f);
        messageBox.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        messageBox.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
