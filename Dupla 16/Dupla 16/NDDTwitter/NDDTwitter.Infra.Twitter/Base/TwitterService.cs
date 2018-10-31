using NDDTwitter.Infra.Twitter.Exceptions;
using NDDTwitter.Infra.Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Base
{
    public class TwitterService : ITwitterService
    {
        public static string consumerKey = "cxA70Rd0XHlhdF4Q6HclYld6J";
        public static string consumerSecret = "aD1yWMptaZCNfRNsHKf1m828TJtm4WchgPDKoeo7WXxESNeobC";
        public static string accessToken = "151562688-U0QC9MKXZWT018JJelgYTiZRnXcNSBMr2Qzngy4O";
        public static string accessTokenSecret = "BeeQtfezAI056EvxM0twzEOCtPkisE3YVv0h90AvLgR0R";

        public ITweet AdicionarTwitter(string messagem)
        {
            SetCredentials();
            ValidadorMessage(messagem);            
            var tweet = Tweet.PublishTweet(messagem);
            ValidaTweet(tweet);

            return tweet;
        }

        public bool RemoverTwitter(long id)
        {
            try
            {
                SetCredentials();
                ValidadorId(id);
                return Tweet.DestroyTweet(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ITweet GetTweet(long id)
        {

            try
            {
                SetCredentials();
                ValidadorId(id);

                return Tweet.GetTweet(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  IEnumerable<ITweet> ListTweetsOnHomeTimeLine()
        {
            try
            {
                SetCredentials();
                var tweets = Timeline.GetHomeTimeline();
                foreach (var item in tweets)
                {
                    ValidadorId(item.Id);
                }
                return tweets;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void SetCredentials()
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }


        public void ValidadorMessage(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
                throw new TwitterExceptionMessageNull();
            if (mensagem.Length > 140)
                throw new TwitterExceptionMessageOver140();
            
        }

        public void ValidaTweet(ITweet tweet)
        {
            if (tweet == null)
                throw new TwitterExceptionMessageRepetida();
        }

        public void ValidadorId(long id)
        {
            if (id  <= 0)
                throw new TwitterExceptionIdNull();
        }
    }
}
