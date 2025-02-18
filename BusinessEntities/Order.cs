#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.BusinessEntities.BusinessEntities
File: Order.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.BusinessEntities
{
	using System;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using Ecng.Common;
	using Ecng.Collections;
	using Ecng.ComponentModel;

	using StockSharp.Messages;
	using StockSharp.Localization;

	/// <summary>
	/// Order.
	/// </summary>
	[DataContract]
	[Serializable]
	[Display(
		ResourceType = typeof(LocalizedStrings),
		Name = LocalizedStrings.OrderKey,
		Description = LocalizedStrings.Str516Key)]
	public class Order : NotifiableObject, IOrderMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Order"/>.
		/// </summary>
		public Order()
		{
		}

		private SecurityId? _securityId;

		SecurityId ISecurityIdMessage.SecurityId
		{
			get => _securityId ??= Security?.Id.ToSecurityId() ?? default;
			set => throw new NotSupportedException();
		}

		Messages.DataType IGeneratedMessage.BuildFrom { get; set; }

		private TimeSpan? _latencyRegistration;

		/// <summary>
		/// Time taken to register an order.
		/// </summary>
		//[TimeSpan]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str538Key,
			Description = LocalizedStrings.Str518Key,
			GroupName = LocalizedStrings.Str161Key,
			Order = 1000)]
		public TimeSpan? LatencyRegistration
		{
			get => _latencyRegistration;
			set
			{
				if (_latencyRegistration == value)
					return;

				_latencyRegistration = value;
				NotifyChanged();
			}
		}

		private TimeSpan? _latencyCancellation;

		/// <summary>
		/// Time taken to cancel an order.
		/// </summary>
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str537Key,
			Description = LocalizedStrings.Str520Key,
			GroupName = LocalizedStrings.Str161Key,
			Order = 1001)]
		public TimeSpan? LatencyCancellation
		{
			get => _latencyCancellation;
			set
			{
				if (_latencyCancellation == value)
					return;

				_latencyCancellation = value;
				NotifyChanged();
			}
		}

		private TimeSpan? _latencyEdition;

		/// <summary>
		/// Time taken to edit an order.
		/// </summary>
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.EditionKey,
			Description = LocalizedStrings.EditionLatencyKey,
			GroupName = LocalizedStrings.Str161Key,
			Order = 1002)]
		public TimeSpan? LatencyEdition
		{
			get => _latencyEdition;
			set
			{
				if (_latencyEdition == value)
					return;

				_latencyEdition = value;
				NotifyChanged();
			}
		}

		private long? _id;

		/// <summary>
		/// Order ID.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str361Key,
			Description = LocalizedStrings.OrderIdStringKey + LocalizedStrings.Dot,
			GroupName = LocalizedStrings.GeneralKey)]
		public long? Id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;

				_id = value;
				NotifyChanged();
			}
		}

		private string _stringId;

		/// <summary>
		/// Order ID (as string, if electronic board does not use numeric order ID representation).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str521Key,
			Description = LocalizedStrings.OrderIdStringDescKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public string StringId
		{
			get => _stringId;
			set
			{
				_stringId = value;
				NotifyChanged();
			}
		}

		private string _boardId;

		/// <summary>
		/// Board order id. Uses in case of <see cref="Id"/> and <see cref="StringId"/> is a brokerage system ids.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str117Key,
			Description = LocalizedStrings.Str118Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public string BoardId
		{
			get => _boardId;
			set
			{
				_boardId = value;
				NotifyChanged();
			}
		}

		private DateTimeOffset _time;

		/// <summary>
		/// Order placing time on exchange.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str522Key,
			Description = LocalizedStrings.Str523Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public DateTimeOffset Time
		{
			get => _time;
			set
			{
				if (_time == value)
					return;

				_time = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Transaction ID. Automatically set when the <see cref="ITransactionProvider.RegisterOrder"/> method called.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.TransactionKey,
			Description = LocalizedStrings.TransactionIdKey + LocalizedStrings.Dot,
			GroupName = LocalizedStrings.GeneralKey)]
		public long TransactionId { get; set; }

		/// <summary>
		/// Security, for which an order is being placed.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.SecurityKey,
			Description = LocalizedStrings.Str524Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public Security Security { get; set; }

		private OrderStates _state;

		/// <summary>
		/// Order state.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.StateKey,
			Description = LocalizedStrings.Str134Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public OrderStates State
		{
			get => _state;
			set
			{
				if (_state == value)
					return;

				_state = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Portfolio, in which the order is being traded.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.PortfolioKey,
			Description = LocalizedStrings.Str525Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public Portfolio Portfolio { get; set; }

		private DateTimeOffset _serverTime;

		/// <inheritdoc/>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str528Key,
			Description = LocalizedStrings.Str529Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public DateTimeOffset ServerTime
		{
			get => _serverTime;
			set
			{
				if (_serverTime == value)
					return;

				_serverTime = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Time of last order change (Cancellation, Fill).
		/// </summary>
		[Obsolete("Use LastChangeTime property.")]
		[Browsable(false)]
		public DateTimeOffset LastChangeTime
		{
			get => ServerTime;
			set => ServerTime = value;
		}

		private DateTimeOffset _localTime;

		/// <summary>
		/// Last order change local time (Cancellation, Fill).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str530Key,
			Description = LocalizedStrings.Str531Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public DateTimeOffset LocalTime
		{
			get => _localTime;
			set
			{
				if (_localTime == value)
					return;

				_localTime = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Order price.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.PriceKey,
			Description = LocalizedStrings.OrderPriceKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal Price { get; set; }

		/// <summary>
		/// Number of contracts in the order.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.VolumeKey,
			Description = LocalizedStrings.OrderVolumeKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal Volume { get; set; }

		/// <summary>
		/// Visible quantity of contracts in order.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.VisibleVolumeKey,
			Description = LocalizedStrings.Str127Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal? VisibleVolume { get; set; }

		/// <inheritdoc/>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str128Key,
			Description = LocalizedStrings.Str129Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public Sides Side { get; set; }

		/// <summary>
		/// Order side (buy or sell).
		/// </summary>
		[Browsable(false)]
		[Obsolete("Use Direction property.")]
		public Sides Direction
		{
			get => Side;
			set => Side = value;
		}

		private decimal _balance;

		/// <summary>
		/// Order contracts balance.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.BalanceKey,
			Description = LocalizedStrings.Str131Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal Balance
		{
			get => _balance;
			set
			{
				if (_balance == value)
					return;

				_balance = value;
				NotifyChanged();
			}
		}

		private long? _status;

		/// <summary>
		/// System order status.
		/// </summary>
		[DataMember]
		[Browsable(false)]
		public long? Status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;

				_status = value;
				NotifyChanged();
			}
		}

		private bool? _isSystem;

		/// <summary>
		/// Is a system trade.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str139Key,
			Description = LocalizedStrings.Str140Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public bool? IsSystem
		{
			get => _isSystem;
			set
			{
				if (_isSystem == value)
					return;

				_isSystem = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Placed order comment.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.CommentKey,
			Description = LocalizedStrings.Str136Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public string Comment { get; set; }

		/// <summary>
		/// Order type.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str132Key,
			Description = LocalizedStrings.Str133Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public OrderTypes? Type { get; set; }

		private DateTimeOffset? _expiryDate;

		/// <summary>
		/// Order expiry time. The default is <see langword="null" />, which mean (GTC).
		/// </summary>
		/// <remarks>
		/// If the value is <see langword="null"/>, then the order is registered until cancel. Otherwise, the period is specified.
		/// </remarks>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str141Key,
			Description = LocalizedStrings.Str142Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public DateTimeOffset? ExpiryDate
		{
			get => _expiryDate;
			set
			{
				if (_expiryDate == value)
					return;

				_expiryDate = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Order condition (e.g., stop- and algo- orders parameters).
		/// </summary>
		[XmlIgnore]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str154Key,
			Description = LocalizedStrings.Str155Key,
			GroupName = LocalizedStrings.Str156Key)]
		public OrderCondition Condition { get; set; }

		/// <summary>
		/// Limit order time in force.
		/// </summary>
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.TimeInForceKey,
			Description = LocalizedStrings.Str232Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public TimeInForce? TimeInForce { get; set; }

		private Order _derivedOrder;

		/// <summary>
		/// Exchange order that was created by the stop-order when the condition is activated (<see langword="null" /> if a stop condition has not been activated).
		/// </summary>
		//[DataMember]
		[XmlIgnore]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str532Key,
			Description = LocalizedStrings.Str533Key,
			GroupName = LocalizedStrings.Str156Key)]
		[Obsolete("No longer used.")]
		public Order DerivedOrder
		{
			get => _derivedOrder;
			set
			{
				if (_derivedOrder == value)
					return;

				_derivedOrder = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Commission (broker, exchange etc.).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.CommissionKey,
			Description = LocalizedStrings.Str160Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal? Commission { get; set; }

		/// <summary>
		/// Commission currency. Can be <see lnagword="null"/>.
		/// </summary>
		public string CommissionCurrency { get; set; }

		/// <summary>
		/// User's order ID.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str165Key,
			Description = LocalizedStrings.Str166Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public string UserOrderId { get; set; }

		/// <summary>
		/// Strategy id.
		/// </summary>
		[DataMember]
		public string StrategyId { get; set; }

		/// <summary>
		/// Broker firm code.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.BrokerKey,
			Description = LocalizedStrings.Str2619Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public string BrokerCode { get; set; }

		/// <summary>
		/// Client code assigned by the broker.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.ClientCodeKey,
			Description = LocalizedStrings.ClientCodeDescKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public string ClientCode { get; set; }

		/// <summary>
		/// Trading security currency.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.CurrencyKey,
			Description = LocalizedStrings.Str382Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public CurrencyTypes? Currency { get; set; }

		/// <summary>
		/// Is the order of market-maker.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.MarketMakerKey,
			Description = LocalizedStrings.MarketMakerOrderKey + LocalizedStrings.Dot,
			GroupName = LocalizedStrings.GeneralKey)]
		public bool? IsMarketMaker { get; set; }

		/// <summary>
		/// Is margin enabled.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.MarginKey,
			Description = LocalizedStrings.IsMarginKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public bool? IsMargin { get; set; }

		/// <summary>
		/// Slippage in trade price.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str163Key,
			Description = LocalizedStrings.Str164Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public decimal? Slippage { get; set; }

		/// <summary>
		/// Is order manual.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.ManualKey,
			Description = LocalizedStrings.IsOrderManualKey,
			GroupName = LocalizedStrings.GeneralKey)]
		public bool? IsManual { get; set; }

		/// <summary>
		/// Average execution price.
		/// </summary>
		[DataMember]
		public decimal? AveragePrice { get; set; }

		/// <summary>
		/// Yield.
		/// </summary>
		[DataMember]
		public decimal? Yield { get; set; }

		/// <summary>
		/// Minimum quantity of an order to be executed.
		/// </summary>
		[DataMember]
		public decimal? MinVolume { get; set; }

		/// <summary>
		/// Position effect.
		/// </summary>
		[DataMember]
		public OrderPositionEffects? PositionEffect { get; set; }

		/// <summary>
		/// Post-only order.
		/// </summary>
		[DataMember]
		public bool? PostOnly { get; set; }

		/// <summary>
		/// Sequence number.
		/// </summary>
		/// <remarks>Zero means no information.</remarks>
		[DataMember]
		public long SeqNum { get; set; }

		/// <summary>
		/// Margin leverage.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.LeverageKey,
			Description = LocalizedStrings.Str261Key,
			GroupName = LocalizedStrings.GeneralKey)]
		public int? Leverage { get; set; }

		/// <inheritdoc />
		public override string ToString()
		{
			var str = LocalizedStrings.Str534Params
				.Put(TransactionId, Id == null ? StringId : Id.To<string>(), Security?.Id, Portfolio?.Name, Side == Sides.Buy ? LocalizedStrings.Str403 : LocalizedStrings.Str404, Price, Volume, State, Balance, Type);

			if (!UserOrderId.IsEmpty())
				str += $" UID={UserOrderId}";

			if (!StrategyId.IsEmpty())
				str += $" Strategy={StrategyId}";

			if (Condition != null)
				str += $" Condition={Condition}";

			if (AveragePrice != null)
				str += $" AvgPrice={AveragePrice}";

			if (MinVolume != null)
				str += $" MinVolume={MinVolume}";

			if (PositionEffect != null)
				str += $" PosEffect={PositionEffect.Value}";

			if (PostOnly != null)
				str += $",PostOnly={PostOnly.Value}";

			if (SeqNum != 0)
				str += $",SeqNum={SeqNum}";

			if (Leverage != null)
				str += $",Leverage={Leverage.Value}";

			return str;
		}
	}
}
