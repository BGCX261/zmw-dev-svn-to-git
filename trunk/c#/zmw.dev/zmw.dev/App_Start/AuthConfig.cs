﻿using System.Linq;

namespace zmw.dev.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // このサイトのユーザーが、Microsoft、Facebook、および Twitter などの他のサイトのアカウントを使用してログインできるようにするには、
            // このサイトを更新する必要があります。詳細については、http://go.microsoft.com/fwlink/?LinkID=252166 を参照してください

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
