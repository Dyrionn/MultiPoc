using System;
using MultiPoc.Repository;
using MultiPoc.Service.Contract;

namespace MultiPoc.Service
{
    public class RedisChannelService : IRedisChannelService
    {
        private RedisRepository<Object> _testRepository;
        public RedisChannelService()
        {
            _testRepository = new Repository.RedisRepository<Object>("localhost");
        }

        public void PublhishOnChannel(string channelName, string message)
        {
            _testRepository.redis.GetSubscriber().Publish(channelName, message);
        }

        public bool SubscribeChannel(string channelName)
        {
            //Test on ConsoleApp
            _testRepository.redis.GetSubscriber().Subscribe(channelName, (c, v) =>
            {
                Console.WriteLine("Got notification: " + (string)v);
            });

            //_testRepository.redis.GetSubscriber().Subscribe(channelName, (c, v) => {
            //    _testRepository.Add("channel:" + channelName + ":" + new Guid().ToString(), "notification: "  +  (string)v);
            //});

            return _testRepository.redis.GetSubscriber().IsConnected(channelName);
        }
    }
}
