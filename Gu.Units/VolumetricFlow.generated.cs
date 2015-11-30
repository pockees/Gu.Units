﻿namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.VolumetricFlow"/>.
    /// </summary>
    // [TypeConverter(typeof(VolumetricFlowTypeConverter))]
    [Serializable]
    public partial struct VolumetricFlow : IQuantity<VolumetricFlowUnit>, IComparable<VolumetricFlow>, IEquatable<VolumetricFlow>
    {
        public static readonly VolumetricFlow Zero = new VolumetricFlow();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/>.
        /// </summary>
        internal readonly double cubicMetresPerSecond;

        private VolumetricFlow(double cubicMetresPerSecond)
        {
            this.cubicMetresPerSecond = cubicMetresPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        public VolumetricFlow(double value, VolumetricFlowUnit unit)
        {
            this.cubicMetresPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.cubicMetresPerSecond;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.VolumetricFlowUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public VolumetricFlowUnit SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

        /// <summary>
        /// The quantity in cubicMetresPerSecond".
        /// </summary>
        public double CubicMetresPerSecond
        {
            get
            {
                return this.cubicMetresPerSecond;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <returns></returns>
		public static VolumetricFlow Parse(string s)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static VolumetricFlow Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, provider);
        }

        public static VolumetricFlow Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static VolumetricFlow Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out VolumetricFlow value)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out VolumetricFlow value)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out VolumetricFlow value)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out VolumetricFlow value)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.VolumetricFlow"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow ReadFrom(XmlReader reader)
        {
            var v = new VolumetricFlow();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static VolumetricFlow From(double value, VolumetricFlowUnit unit)
        {
            return new VolumetricFlow(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicMetresPerSecond">The value in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/></param>
        public static VolumetricFlow FromCubicMetresPerSecond(double cubicMetresPerSecond)
        {
            return new VolumetricFlow(cubicMetresPerSecond);
        }

        public static Area operator /(VolumetricFlow left, Speed right)
        {
            return Area.FromSquareMetres(left.cubicMetresPerSecond / right.metresPerSecond);
        }

        public static Volume operator *(VolumetricFlow left, Time right)
        {
            return Volume.FromCubicMetres(left.cubicMetresPerSecond * right.seconds);
        }

        public static Speed operator /(VolumetricFlow left, Area right)
        {
            return Speed.FromMetresPerSecond(left.cubicMetresPerSecond / right.squareMetres);
        }

        public static Frequency operator /(VolumetricFlow left, Volume right)
        {
            return Frequency.FromHertz(left.cubicMetresPerSecond / right.cubicMetres);
        }

        public static double operator /(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond / right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlow"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator ==(VolumetricFlow left, VolumetricFlow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlow"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator !=(VolumetricFlow left, VolumetricFlow right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is less than another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond < right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is greater than another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond > right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is less than or equal to another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond <= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is greater than or equal to another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond >= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="left"/> and returns the result.</returns>
        public static VolumetricFlow operator *(double left, VolumetricFlow right)
        {
            return new VolumetricFlow(left * right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator *(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator /(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.VolumetricFlow"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static VolumetricFlow operator +(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond + right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Subtracts an VolumetricFlow from another VolumetricFlow and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.VolumetricFlow"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.VolumetricFlow"/> (the subtrahend).</param>
        public static VolumetricFlow operator -(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond - right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.VolumetricFlow"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator -(VolumetricFlow volumetricFlow)
        {
            return new VolumetricFlow(-1 * volumetricFlow.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="volumetricFlow"/>.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator +(VolumetricFlow volumetricFlow)
        {
            return volumetricFlow;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(VolumetricFlowUnit unit)
        {
            return unit.FromSiUnit(this.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/s\"</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/s\"</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m³/s</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m³/s</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(VolumetricFlowUnit unit)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(string.Empty, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(VolumetricFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(string.Empty, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, VolumetricFlowUnit unit)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, VolumetricFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        private string ToString(QuantityFormat<VolumetricFlowUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.VolumetricFlow"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.VolumetricFlow"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare to this instance.</param>
        public int CompareTo(VolumetricFlow quantity)
        {
            return this.cubicMetresPerSecond.CompareTo(quantity.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlow"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        public bool Equals(VolumetricFlow other)
        {
            return this.cubicMetresPerSecond.Equals(other.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlow"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(VolumetricFlow other, VolumetricFlow tolerance)
        {
            Ensure.GreaterThan(tolerance.cubicMetresPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.cubicMetresPerSecond - other.cubicMetresPerSecond) < tolerance.cubicMetresPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VolumetricFlow && this.Equals((VolumetricFlow)obj);
        }

        public override int GetHashCode()
        {
            return this.cubicMetresPerSecond.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, 
        /// you should return null (Nothing in Visual Basic) from this method, and instead, 
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "cubicMetresPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.cubicMetresPerSecond);
        }
    }
}