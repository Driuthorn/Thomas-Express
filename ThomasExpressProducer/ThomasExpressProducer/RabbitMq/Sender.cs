using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;
using Serilog;
using System;
using System.Text;

namespace ThomasExpressProducer.RabbitMq
{
    public class Sender
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration = new RabbitMqConfiguration();
        private readonly BasicPropertiesConfiguration _basicPropertiesConfiguration = new BasicPropertiesConfiguration();

        private IModel _model;
        private IConnection _connection;
        private IBasicProperties _basicProperties;

        public void OpenConnection()
        {
            _connection = GetConnectionFactory().CreateConnection();
            _model = _connection.CreateModel();
            _basicProperties = GetProperties();
        }

        public void EnableTxMode()
        {
            _model.TxSelect();
        }

        public void CloseConnection()
        {
            try
            {
                Log.Logger.Information("Closing connection");
                if (_model != null) _model.Close();
                if (_connection != null) _connection.Close();
                Log.Logger.Information("Connection closed");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Error CloseConnection");
            }
        }
        public void Publish<T>(T obj)
        {
            _model.BasicPublish(exchange: _rabbitMqConfiguration.Exchange, routingKey: string.Empty, basicProperties: _basicProperties, body: ConvertObjectSender(obj));
        }

        public void Commit()
        {
            try
            {
                _model.TxCommit();
            }
            catch (Exception)
            {
                _model.TxRollback();
            }
        }

        private BasicProperties GetProperties()
        {
            return new BasicProperties
            {
                Persistent = _basicPropertiesConfiguration.Persistent,
                Expiration = _basicPropertiesConfiguration.Expiration
            };
        }

        private ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.Host,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password,
                RequestedHeartbeat = _rabbitMqConfiguration.RequestHeartBeatInSeconds,
                VirtualHost = _rabbitMqConfiguration.VirtualHost,
                Port = _rabbitMqConfiguration.Port
            };
        }

        private static byte[] ConvertObjectSender<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
