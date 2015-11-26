﻿namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.SpecificEnergy"/>.
    /// </summary>
    [Serializable, TypeConverter(typeof(SpecificEnergyTypeConverter))]
    public partial struct SpecificEnergy : IComparable<SpecificEnergy>, IEquatable<SpecificEnergy>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I2, TimeUnit, INeg2>, IQuantity<SpecificEnergyUnit>
    {
        public static readonly SpecificEnergy Zero = new SpecificEnergy();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/>.
        /// </summary>
        internal readonly double joulesPerKilogram;

        private SpecificEnergy(double joulesPerKilogram)
        {
            this.joulesPerKilogram = joulesPerKilogram;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
        public SpecificEnergy(double value, SpecificEnergyUnit unit)
        {
            this.joulesPerKilogram = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.joulesPerKilogram;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.SpecificEnergyUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public SpecificEnergyUnit SiUnit => SpecificEnergyUnit.JoulesPerKilogram;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => SpecificEnergyUnit.JoulesPerKilogram;

        /// <summary>
        /// The quantity in joulesPerKilogram".
        /// </summary>
        public double JoulesPerKilogram
        {
            get
            {
                return this.joulesPerKilogram;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
		public static SpecificEnergy Parse(string s)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static SpecificEnergy Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(s, From, NumberStyles.Float, provider);
        }

        public static SpecificEnergy Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static SpecificEnergy Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out SpecificEnergy value)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out SpecificEnergy value)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out SpecificEnergy value)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out SpecificEnergy value)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.SpecificEnergy"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.SpecificEnergy"/></returns>
        public static SpecificEnergy ReadFrom(XmlReader reader)
        {
            var v = new SpecificEnergy();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static SpecificEnergy From(double value, SpecificEnergyUnit unit)
        {
            return new SpecificEnergy(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="joulesPerKilogram">The value in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/></param>
        public static SpecificEnergy FromJoulesPerKilogram(double joulesPerKilogram)
        {
            return new SpecificEnergy(joulesPerKilogram);
        }

        public static Length operator /(SpecificEnergy left, Acceleration right)
        {
            return Length.FromMetres(left.joulesPerKilogram / right.metresPerSecondSquared);
        }

        public static Pressure operator *(SpecificEnergy left, Density right)
        {
            return Pressure.FromPascals(left.joulesPerKilogram * right.kilogramsPerCubicMetre);
        }

        public static Energy operator *(SpecificEnergy left, Mass right)
        {
            return Energy.FromJoules(left.joulesPerKilogram * right.kilograms);
        }

        public static Speed operator /(SpecificEnergy left, Speed right)
        {
            return Speed.FromMetresPerSecond(left.joulesPerKilogram / right.metresPerSecond);
        }

        public static Acceleration operator /(SpecificEnergy left, Length right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.joulesPerKilogram / right.metres);
        }

        public static double operator /(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram / right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergy"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator ==(SpecificEnergy left, SpecificEnergy right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergy"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator !=(SpecificEnergy left, SpecificEnergy right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is less than another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram < right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is greater than another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram > right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is less than or equal to another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram <= right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is greater than or equal to another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram >= right.joulesPerKilogram;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.</returns>
        public static SpecificEnergy operator *(double left, SpecificEnergy right)
        {
            return new SpecificEnergy(left * right.joulesPerKilogram);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator *(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.joulesPerKilogram * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator /(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.joulesPerKilogram / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.SpecificEnergy"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static SpecificEnergy operator +(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.joulesPerKilogram + right.joulesPerKilogram);
        }

        /// <summary>
        /// Subtracts an SpecificEnergy from another SpecificEnergy and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/> (the subtrahend).</param>
        public static SpecificEnergy operator -(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.joulesPerKilogram - right.joulesPerKilogram);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.SpecificEnergy"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="specificEnergy">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator -(SpecificEnergy specificEnergy)
        {
            return new SpecificEnergy(-1 * specificEnergy.joulesPerKilogram);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="specificEnergy"/>.
        /// </returns>
        /// <param name="specificEnergy">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator +(SpecificEnergy specificEnergy)
        {
            return specificEnergy;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(SpecificEnergyUnit unit)
        {
            return unit.FromSiUnit(this.joulesPerKilogram);
        }

        public override string ToString()
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, null);
        }

        public string ToString(string format)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, null);
        }

        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(SpecificEnergyUnit unit)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(string.Empty, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, SpecificEnergyUnit unit)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, IFormatProvider formatProvider, SpecificEnergyUnit unit)
        {
            var quantityFormat = FormatParser<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        private string ToString(QuantityFormat<SpecificEnergyUnit> format, IFormatProvider formatProvider)
        {
            var scalarValue = format.Unit.GetScalarValue(this);
            var provider = formatProvider ?? (IFormatProvider)NumberFormatInfo.CurrentInfo;
            return string.Format(provider, format.Format, scalarValue);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.SpecificEnergy"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.SpecificEnergy"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare to this instance.</param>
        public int CompareTo(SpecificEnergy quantity)
        {
            return this.joulesPerKilogram.CompareTo(quantity.joulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificEnergy"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        public bool Equals(SpecificEnergy other)
        {
            return this.joulesPerKilogram.Equals(other.joulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificEnergy"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(SpecificEnergy other, double tolerance)
        {
            return Math.Abs(this.joulesPerKilogram - other.joulesPerKilogram) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpecificEnergy && this.Equals((SpecificEnergy)obj);
        }

        public override int GetHashCode()
        {
            return this.joulesPerKilogram.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "joulesPerKilogram", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.joulesPerKilogram);
        }
    }
}