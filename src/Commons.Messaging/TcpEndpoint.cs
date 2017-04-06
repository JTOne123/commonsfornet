﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Json;
using NetMQ;
using NetMQ.Sockets;

namespace Commons.Messaging
{
    public class TcpEndpoint : IEndpoint
    {
		private readonly RequestSocket req;

		public TcpEndpoint(string address)
		{
			Address = address;
			req = new RequestSocket(address);
		}

	    public void Send(object message)
	    {
			var type = message.GetType().FullName;
			var json = JsonMapper.ToJson(message);
			req.SendFrame(type, true);
			req.SendFrame(json);
	    }

	    public string Address { get; }

	    public void Dispose()
	    {
			req.Close();
	    }
    }
}
