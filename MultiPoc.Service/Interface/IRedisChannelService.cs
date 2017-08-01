using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPoc.Service.Contract
{
    public interface IRedisChannelService
    {
        void PublhishOnChannel(string channelName, string message);
        bool SubscribeChannel(string channelName);

    }
}
