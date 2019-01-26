using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kingofTime
{
    class webscraping
    {
            /// <summary>
            /// 引数urlにアクセスした際に取得できるHTMLを返します。
            /// </summary>
            /// <param name="url">URL(アドレス)</param>
            /// <returns>取得したHTML</returns>
            public string GetHtml(string url)
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
}
