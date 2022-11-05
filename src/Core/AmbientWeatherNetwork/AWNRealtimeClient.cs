//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Common.Observe;
//using Core.AmbientWeatherNetwork.Dto;
//using Serilog;
//using SocketIOClient;

//namespace Core.AmbientWeatherNetwork;

//// TODO: consider struct
//public record OnSubscribeEventArgs(SubscribeResposne? subscribeResponse);
//public record OnDataReceivedEventArgs(Device? Device);

//public interface IAWNRealtimeClient : IAsyncDisposable
//{
//	/// <summary>
//	/// Handler for our OnDataReceived event
//	/// </summary>
//	delegate void OnDataReceivedHandler(object sender, OnDataReceivedEventArgs args);

//	/// <summary>
//	/// The OnDataReceived Event fires when it receives an event from the Ambient Weather API
//	/// </summary>
//	event OnDataReceivedHandler OnDataReceived;

//	/// <summary>
//	/// Handler for out OnSubcribe event
//	/// </summary>
//	/// <param name="sender"></param>
//	/// <param name="token">Hands a <see cref="JToken"/> from the websocket.</param>
//	delegate void OnSubcribeHandler(object sender, OnSubscribeEventArgs args);

//	/// <summary>
//	/// The OnSubcribe event fires when a successful subscription is negotiated with the Ambient Weather Websocket server
//	/// </summary>
//	event OnSubcribeHandler OnSubscribe;

//	/// <summary>
//	/// Opens a connection and subscribes to the Ambient Weather service
//	/// </summary>
//	/// <param name="token">Cancellation token.</param>
//	/// <returns>Returns a <see cref="Task"/>.</returns>
//	/// <exception cref="ArgumentException">Throws an argument exception if <see cref="CirrusConfig.ApplicationKey"/> or <see cref="CirrusConfig.ApiKeys"/> is null, empty, or whitespace.</exception>
//	Task OpenConnectionAsync(CancellationToken token = default);

//	/// <summary>
//	/// Unsubscribes from the Ambient Weather Service and closes the SocketIO connection
//	/// </summary>
//	/// <returns>Returns a <see cref="Task"/>.</returns>
//	/// <param name="token">Cancellation token.</param>
//	Task CloseConnectionAsync(CancellationToken token = default);

//	/// <summary>
//	/// Subscribes to the Ambient Weather Service
//	/// </summary>
//	/// <returns>Returns a <see cref="Task"/>.</returns>
//	/// <param name="token">Cancellation token.</param>
//	Task SubscribeAsync(CancellationToken token = default);

//	/// <summary>
//	/// Unsubscribes from the Ambient Weather Service
//	/// This is useful for retrieving a list of invalid API keys, without closing the websocket connection or destroying this instance.
//	/// </summary>
//	/// <param name="token">Cancellation token.</param>
//	/// <returns>Returns a <see cref="Task"/>.</returns>
//	Task UnsubscribeAsync(CancellationToken token = default);
//}

//public class AWNRealtimeClient : IAWNRealtimeClient
//{
//	private const string Host = "https://dash2.ambientweather.net/";

//	private static readonly ILogger _logger = LogContext.ForClass<AWNRealtimeClient>();

//	private readonly string _apiKey;
//	private readonly string _applicationKey;
//	private readonly SocketIO _client;

//	public event IAWNRealtimeClient.OnDataReceivedHandler? OnDataReceived;
//	public event IAWNRealtimeClient.OnSubcribeHandler? OnSubscribe;

//	public AWNRealtimeClient(string apiKey, string applicationKey)
//	{
//		_apiKey = apiKey;
//		_applicationKey = applicationKey;
//		_client = CreateClient();
//	}

//	public async Task OpenConnectionAsync(CancellationToken token = default)
//	{
//		// TODO: tracing
//		_logger.Information("Opening connection to AWN WebSocket Endpoint");

//		try
//		{
//			_client.On("subscribed", OnInternalSubscribeEvent);
//			_client.On("data", OnInternalDataEvent);
//			_client.OnConnected += OnInternalConnectEvent;
//			_client.OnDisconnected += OnInternalDisconnectEvent;
//			_client.OnError += (object? sender, string error) => { _logger.Error("SocketIO Error: {@error}", error); };
//			_client.OnPing += (object? sender, EventArgs _) => { _logger.Verbose("Ping"); };
//			_client.OnPong += (object? sender, TimeSpan duration) => { _logger.Verbose("Pong: {@duration}", duration.ToString()); };
//			_client.OnReconnectAttempt += (object? sender, int count) => { _logger.Verbose("Reconnect attempt number: {@count}", count); };
//			_client.OnReconnected += (object? sender, int count) => { _logger.Verbose("Reconnected. Number: {@count}", count); };
//			_client.OnReconnectError += (object? sender, Exception e) => { _logger.Error(e, "Reconnect Error"); };

//			_logger.Information("Opening websocket connection: {BaseAddress}", Host);
//			_logger.Verbose("test message");
//			await _client.ConnectAsync();
//			await _client.EmitAsync("connect", token);
//		} catch (Exception e)
//		{
//			_logger.Error(e, "Failed to open a connection with AmbientWeatherNetwork");
//		}
		
//	}

//	public async Task CloseConnectionAsync(CancellationToken token = default)
//	{
//		_logger.Information("Closing connection to Ambient Weather WebSocket endpoint");

//		await UnsubscribeAsync(token);
//		await _client.EmitAsync("disconnect", token);
//		await _client.DisconnectAsync();
//	}

//	public Task SubscribeAsync(CancellationToken token = default)
//	{
//		if (_client.Disconnected)
//		{
//			_logger.Warning("Cannot subscribe while client is disconnected.");
//			return Task.CompletedTask;
//		}

//		_logger.Information("Subscribing to WebSocket service");
//		return _client.EmitAsync("subscribe", token, new { apiKeys = new string[] { _apiKey } });
//	}

//	public Task UnsubscribeAsync(CancellationToken token = default)
//	{
//		if (_client.Disconnected)
//		{
//			_logger.Warning("Cannot subscribe while client is disconnected.");
//			return Task.CompletedTask;
//		}

//		_logger.Information("Unsubscribing from the Ambient Weather websocket service");
//		return _client.EmitAsync("unsubscribe", token);
//	}

//	public async ValueTask DisposeAsync()
//	{
//		if (_client == null) return;

//		// Unregister our handlers from SocketIO
//		_client.Off("subscribed");
//		_client.Off("data");

//		// Unregister our internal handlers
//		_client.OnConnected -= OnInternalConnectEvent;
//		_client.OnDisconnected -= OnInternalDisconnectEvent;

//		await CloseConnectionAsync();
//	}

//	private SocketIO CreateClient()
//	{
//		if (string.IsNullOrWhiteSpace(_apiKey))
//			throw new ArgumentOutOfRangeException("ApiKey", "AmbientWeather ApiKey must not be null or empty.");

//		if (string.IsNullOrWhiteSpace(_applicationKey))
//			throw new ArgumentOutOfRangeException("ApplicationKey", "AmbientWeather ApplicationKey must not be null or empty.");

//		return new SocketIO(Host, new SocketIOOptions
//		{
//			EIO = 4,
//			Query = new Dictionary<string, string>
//				{
//					{ "api", "1" },
//					{ "applicationKey", _applicationKey! }
//				},
//			Reconnection = true,
//			ReconnectionDelay = 5000,
//			ReconnectionDelayMax = 30000,
//		});
//	}

//	private void OnInternalDisconnectEvent(object? sender, string e)
//	{
//		_logger.Information($"API Disconnected with message: {e}");
//	}

//	/// <summary>
//	/// The SocketIO Client library forces our method to have this non-standard
//	/// async return type.
//	/// </summary>
//	private async void OnInternalConnectEvent(object? sender, EventArgs e)
//	{
//		_logger.Information("Connected to API");
//		_logger.Debug("Sending Subcribe Command");

//		await _client.EmitAsync("subscribe", new { apiKeys = new string[] { _apiKey } });
//	}

//	private void OnInternalSubscribeEvent(SocketIOResponse obj)
//	{
//		_logger.Information("Subscribed to service");
//		_logger.Verbose("Object: {@Obj}", obj.GetValue());

		
//		if (OnSubscribe is object)
//		{
//			var response = obj.GetValue().Deserialize<SubscribeResposne>();
//			OnSubscribe.Invoke(this, new OnSubscribeEventArgs(response));
//		}
//	}

//	private void OnInternalDataEvent(SocketIOResponse obj)
//	{
//		_logger.Debug("Received data event");
//		_logger.Verbose("Object: {@Obj}", obj.GetValue());
		
//		if (OnDataReceived is object)
//		{
//			var device = obj.GetValue().Deserialize<Device>();
//			OnDataReceived.Invoke(this, new OnDataReceivedEventArgs(device));
//		}
//	}
//}
