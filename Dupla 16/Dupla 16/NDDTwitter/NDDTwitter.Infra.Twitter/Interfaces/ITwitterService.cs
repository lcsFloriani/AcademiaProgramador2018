using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Interfaces
{
    public interface ITwitterService
    {
        ITweet AdicionarTwitter(string messagem);

        bool RemoverTwitter(long id);

        ITweet GetTweet(long id);

        IEnumerable<ITweet> ListTweetsOnHomeTimeLine();

        void SetCredentials();
    }
}
