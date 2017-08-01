using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace MultiPoc.Service
{
    public class RabbitRpc
    {
        public IConnection connection;
        public IModel channel;
        private QueueingBasicConsumer consumer;

        public RabbitRpc()
        {

        }

        public RabbitRpc(string serverName)
        {
            var factory = new ConnectionFactory()
                { HostName = !String.IsNullOrEmpty(serverName) ? serverName : "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this.consumer = new QueueingBasicConsumer(this.channel);

            //Process.Start("C:\\Users\\apianor\\Documents\\visual studio 2017\\Projects\\MultiPoc\\MultiPoc.RpcServer\\bin\\Debug\\MultiPoc.RpcServer.exe");
        }

        public string Call(string message)
        {
            //
            string methodResult = String.Empty;

            string replyQueue = channel.QueueDeclare().QueueName;
            channel.BasicConsume(queue: replyQueue, autoAck: true, consumer: this.consumer);

            var corrId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.CorrelationId = corrId;
            props.ReplyTo = replyQueue;

            var messageBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "rpc_queue", basicProperties: props, body: messageBytes);
            
            while (true)
            {
                var ea = consumer.Queue.Dequeue();

                if (ea.BasicProperties.CorrelationId == corrId)
                return Encoding.UTF8.GetString(ea.Body);
            }

        }

        public void Close()
        {
            connection.Close();
        }

    }
}
