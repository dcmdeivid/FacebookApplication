using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FacebookApplication.Models
{
    public class FacebookAuthProvider
    {
        private const string AppId = "";
        private const string Appsecret = "";
        // TODO: verificar todos as permissões necessarias
        private const string Scope = "user_about_me,publish_stream";
        private const string RedirectUri = "http://localhost/FacebookApplication/Home/Callback";

        private readonly FacebookClient _fb;

        private string crossSiteRequestForgeryToken;

        public FacebookAuthProvider()
        {
            this._fb = new FacebookClient();
            this.crossSiteRequestForgeryToken = Guid.NewGuid().ToString();
        }


        public string LoginUrl()
        {

            var state = Convert.ToBase64String(Encoding.UTF8.GetBytes(_fb.SerializeJson(new { csrf = crossSiteRequestForgeryToken })));

            Uri facebookLoginUrl = _fb.GetLoginUrl(
                new
                    {
                        client_id = AppId,
                        client_secret = Appsecret,
                        redirect_uri = RedirectUri,
                        response_type = "code",
                        scope = Scope,
                        state = state
                    });

            return facebookLoginUrl.AbsoluteUri;
        }

        public Boolean IsValidCsrfToken(string state, string sessionCsrfToken)
        {
            dynamic decodedState;

            decodedState = _fb.DeserializeJson(Encoding.UTF8.GetString(Convert.FromBase64String(state)), null);

            if (!(decodedState is IDictionary<string, object>) || !decodedState.ContainsKey("csrf") || sessionCsrfToken != decodedState.csrf)
            {
                return false;
            
            }

            this.crossSiteRequestForgeryToken = sessionCsrfToken;
            return true;

        }

        public String GetAcessToken(string code)
        {

            dynamic result = _fb.Post("oauth/access_token",
                new
                {
                    client_id = AppId,
                    client_secret = Appsecret,
                    redirect_uri = RedirectUri,
                    code = code
                });

            return result.access_token;
        }


        public string CrossSiteRequestForgeryToken
        {
            get
            {
                return crossSiteRequestForgeryToken;
            }
        }

    }
}