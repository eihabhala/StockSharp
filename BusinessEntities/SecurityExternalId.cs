#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.BusinessEntities.BusinessEntities
File: SecurityExternalId.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.BusinessEntities
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Runtime.Serialization;

	using Ecng.Common;
	using Ecng.ComponentModel;

	using StockSharp.Localization;

	/// <summary>
	/// Security IDs in other systems.
	/// </summary>
	[Serializable]
	[DataContract]
	[Display(
		ResourceType = typeof(LocalizedStrings),
		Name = LocalizedStrings.IdentifiersKey,
		Description = LocalizedStrings.Str603Key)]
	public class SecurityExternalId : NotifiableObject, ICloneable<SecurityExternalId>, IEquatable<SecurityExternalId>
	{
		private string _sedol;
		private string _cusip;
		private string _isin;
		private string _ric;
		private string _bloomberg;
		private string _iqFeed;
		private int? _interactiveBrokers;
		private string _plaza;

		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityExternalId"/>.
		/// </summary>
		public SecurityExternalId()
		{
		}

		/// <summary>
		/// ID in SEDOL format (Stock Exchange Daily Official List).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.SedolKey,
			Description = LocalizedStrings.Str351Key)]
		public string Sedol
		{
			get => _sedol;
			set
			{
				_sedol = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in CUSIP format (Committee on Uniform Securities Identification Procedures).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.CusipKey,
			Description = LocalizedStrings.Str352Key)]
		public string Cusip
		{
			get => _cusip;
			set
			{
				_cusip = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in ISIN format (International Securities Identification Number).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.IsinKey,
			Description = LocalizedStrings.Str353Key)]
		public string Isin
		{
			get => _isin;
			set
			{
				_isin = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in RIC format (Reuters Instrument Code).
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.RicKey,
			Description = LocalizedStrings.Str354Key)]
		public string Ric
		{
			get => _ric;
			set
			{
				_ric = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in Bloomberg format.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.BloombergKey,
			Description = LocalizedStrings.Str355Key)]
		public string Bloomberg
		{
			get => _bloomberg;
			set
			{
				_bloomberg = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in IQFeed format.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.IQFeedKey,
			Description = LocalizedStrings.Str356Key)]
		public string IQFeed
		{
			get => _iqFeed;
			set
			{
				_iqFeed = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in Interactive Brokers format.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.InteractiveBrokersKey,
			Description = LocalizedStrings.Str357Key)]
		//[Nullable]
		public int? InteractiveBrokers
		{
			get => _interactiveBrokers;
			set
			{
				_interactiveBrokers = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// ID in Plaza format.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.PlazaKey,
			Description = LocalizedStrings.Str358Key)]
		public string Plaza
		{
			get => _plaza;
			set
			{
				_plaza = value;
				NotifyChanged();
			}
		}

		/// <summary>
		/// Create a copy of <see cref="SecurityExternalId"/>.
		/// </summary>
		/// <returns>Copy.</returns>
		public SecurityExternalId Clone()
		{
			return new SecurityExternalId
			{
				Bloomberg = Bloomberg,
				Cusip = Cusip,
				IQFeed = IQFeed,
				Isin = Isin,
				Ric = Ric,
				Sedol = Sedol,
				InteractiveBrokers = InteractiveBrokers,
				Plaza = Plaza,
			};
		}

		/// <inheritdoc />
		object ICloneable.Clone()
		{
			return Clone();
		}

		/// <inheritdoc />
		public override string ToString()
		{
			var str = string.Empty;

			if (!Bloomberg.IsEmpty())
				str += $" Bloom {Bloomberg}";

			if (!Cusip.IsEmpty())
				str += $" CUSIP {Cusip}";

			if (!IQFeed.IsEmpty())
				str += $" IQFeed {IQFeed}";

			if (!Isin.IsEmpty())
				str += $" ISIN {Isin}";

			if (!Ric.IsEmpty())
				str += $" RIC {Ric}";

			if (!Sedol.IsEmpty())
				str += $" SEDOL {Sedol}";

			if (InteractiveBrokers != null)
				str += $" InteractiveBrokers {InteractiveBrokers}";

			if (!Plaza.IsEmpty())
				str += $" Plaza {Plaza}";

			return str;
		}

		/// <inheritdoc />
		public override int GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Compare <see cref="SecurityExternalId"/> on the equivalence.
		/// </summary>
		/// <param name="other">Another value with which to compare.</param>
		/// <returns><see langword="true" />, if the specified object is equal to the current object, otherwise, <see langword="false" />.</returns>
		public override bool Equals(object other)
		{
			return Equals((SecurityExternalId)other);
		}

		/// <inheritdoc />
		public bool Equals(SecurityExternalId other)
		{
			if (other is null)
				return false;

			if (Bloomberg != other.Bloomberg)
				return false;

			if (Cusip != other.Cusip)
				return false;

			if (IQFeed != other.IQFeed)
				return false;

			if (Isin != other.Isin)
				return false;

			if (Ric != other.Ric)
				return false;

			if (Sedol != other.Sedol)
				return false;

			if (InteractiveBrokers != other.InteractiveBrokers)
				return false;

			if (Plaza != other.Plaza)
				return false;

			return true;
		}

		/// <summary>
		/// Compare the inequality of two identifiers.
		/// </summary>
		/// <param name="left">Left operand.</param>
		/// <param name="right">Right operand.</param>
		/// <returns><see langword="true" />, if identifiers are equal, otherwise, <see langword="false" />.</returns>
		public static bool operator !=(SecurityExternalId left, SecurityExternalId right)
		{
			return !(left == right);
		}

		/// <summary>
		/// Compare two identifiers for equality.
		/// </summary>
		/// <param name="left">Left operand.</param>
		/// <param name="right">Right operand.</param>
		/// <returns><see langword="true" />, if the specified identifiers are equal, otherwise, <see langword="false" />.</returns>
		public static bool operator ==(SecurityExternalId left, SecurityExternalId right)
		{
			return left?.Equals(right) == true;
		}
	}
}