using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace kingofTime.Models
{
    public static class Webscraping
    {
            /// <summary>
            /// 引数urlにアクセスした際に取得できるHTMLを返します。
            /// </summary>
            /// <param name="url">URL(アドレス)</param>
            /// <returns>取得したHTML</returns>
            public static string GetHtml(string url)
            {
                // 指定されたURLに対してのRequestを作成します。
                var req = (HttpWebRequest)WebRequest.Create(url);

                // html取得文字列
                string html = "";

                // 指定したURLに対してReqestを投げてResponseを取得します。
                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                // 取得した文字列をUTF8でエンコードします。
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    // HTMLを取得する。
                    html = sr.ReadToEnd();
                }

                return html;
            }
    }

    public class Login
    {
        private string m_Id = "";
        private string m_Password = "";
        const string LOGIN_ADDRESS = "https://s3.kingtime.jp/admin?send_param=VrllRWUb5PuaG9pCcEgrNoSywgN5Qepqp8JYxrMcsYh9mvHR7qm1iBEC9iLJeKNf3cZJrNFlOIrxfrBPzb%2FVSw%3D%3D";

        //　なんとなく外から見られないようにアクセス制限しとく
        public string LoginID
        {
            set { m_Id = value; }
            private get { return m_Id; }
        }

        //　なんとなく外から見られないようにアクセス制限しとく
        public string LoginPass
        {
            set { m_Password = value; }
            private get { return m_Password; }
        }

        //　とりあえずログインまではできてる臭い？？
        public Login(string id, string pass)
        {
            LoginID = id;
            LoginPass = pass;
        }

        public async Task<CookieContainer> LoginAsync()
        {
            CookieContainer cc;
            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    //ログイン用のPOSTデータ生成
                    var content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "login_id", LoginID },
                        { "pass", LoginPass },
                    });

                    //ログイン
                    await client.PostAsync(LOGIN_ADDRESS, content);

                    //クッキー保存
                    cc = handler.CookieContainer;
                }
            }

            CookieCollection cookies = cc.GetCookies(new Uri(LOGIN_ADDRESS));

            foreach (Cookie c in cookies)
            {
                Console.WriteLine("クッキー名:" + c.Name.ToString());
                Console.WriteLine("クッキーを使うサイトのドメイン名:" + c.Domain.ToString());
                Console.WriteLine("クッキー発行日時:" + c.TimeStamp.ToString() + Environment.NewLine);
            }

            Console.WriteLine("ログイン処理完了！");

            return cc;
        }
    }
}
