using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using System;
using System.Collections;
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
        public TwitterService()
        {
            SetCredentials();     
        }

        public bool DeleteTweet(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            else
                if (Tweet.DestroyTweet(id))
                    return true;
            return false;
        }

        public ITweet GetTweet(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return Tweet.GetTweet(id);
        }

        public IEnumerable<ITweet> ListTweetsOnHomeTimeLine()
        {
            IEnumerable < ITweet > tweets = Timeline.GetHomeTimeline();
            return tweets;
        }

        public ITweet SendTweet(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new PostMessageIsNullOrEmptyException();
            else if (message.Count() > 140)
                throw new PostMessageOverFlowException();
            return Tweet.PublishTweet(message);            
        }

        public void SetCredentials()
        {
            Auth.SetUserCredentials("9s9Kc1qVUs1n9SMzO1IEgADsY", "TSWC6xb0EdjJ362hV4VL17LbHIMbnmGTAl1Zg2BuqpoczgXtI6", "993575029119029248-xZUdtbt2u0Mh6IMY6zd1yu4JLVYvXpH", "Gy7ac131f2eFirJuu39vCvzlx4mWZLSm3sKBxjnv5wpeT");
        }

        public void DeletarUltimos40Tweets()
        {
            foreach (var item in ListTweetsOnHomeTimeLine())
            {
                DeleteTweet(item.Id);
            }
        }
    }
}
