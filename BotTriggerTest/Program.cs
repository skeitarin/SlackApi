using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Bot.Connector;
using System.Web;

namespace BotTriggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // POSTする対象のURL
            var token = "XXXXXXXXXXXXXXXXXXXXXX"; // トークンの取得（http://qiita.com/rubytomato@github/items/6558bfdb37d982891c09）
            var channel = "shimitest"; // 投稿するチャンネル(#は不要）。Direct Messageの場合は[@username]
                var text = "Hello World"; // 投稿するメッセージ
                var url = "https://slack.com/api/chat.postMessage?token=" + token + "&channel=" + channel + "&text=" + text + "&as_user=true";

                // リクエスト作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";

                // レスポンスの取得
                WebResponse res = req.GetResponse();

                // 結果の読み込み
                string htmlStrings = "";
                using (Stream resStream = res.GetResponseStream())
                using (var reader = new StreamReader(resStream, Encoding.GetEncoding("Shift_JIS")))
                    htmlStrings = reader.ReadToEnd();
                Console.WriteLine(htmlStrings);
            Console.ReadLine();

        }
    }
}
